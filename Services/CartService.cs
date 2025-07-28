using Microsoft.JSInterop;
using System.Text.Json;
using KeyStore.Models;
using KeyStore.DAL;
using Microsoft.EntityFrameworkCore;

namespace KeyStore.Services
{
    public interface ICartService
    {
        Task<List<CartItem>> GetCartItemsAsync();
        Task AddToCartAsync(int productId, int quantity = 1);
        Task RemoveFromCartAsync(int productId);
        Task UpdateQuantityAsync(int productId, int quantity);
        Task ClearCartAsync();
        Task<int> GetCartCountAsync();
        Task<decimal> GetCartTotalAsync();
        event Action? OnCartChanged;
    }

    public class CartService : ICartService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IDbContextFactory<Contexto> _dbContextFactory;
        private const string CART_KEY = "keystore_cart";

        public event Action? OnCartChanged;

        public CartService(IJSRuntime jsRuntime, IDbContextFactory<Contexto> dbContextFactory)
        {
            _jsRuntime = jsRuntime;
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<CartItem>> GetCartItemsAsync()
        {
            try
            {
                var cartJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", CART_KEY);

                if (string.IsNullOrEmpty(cartJson))
                    return new List<CartItem>();

                var cartData = JsonSerializer.Deserialize<Dictionary<int, int>>(cartJson) ?? new();

                if (!cartData.Any())
                    return new List<CartItem>();

                await using var context = await _dbContextFactory.CreateDbContextAsync();
                var productos = await context.Productos
                    .Where(p => cartData.Keys.Contains(p.Id))
                    .ToListAsync();

                return cartData.Select(kvp => new CartItem
                {
                    ProductId = kvp.Key,
                    Quantity = kvp.Value,
                    Product = productos.FirstOrDefault(p => p.Id == kvp.Key) ?? new Producto()
                }).Where(item => item.Product.Id != 0).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting cart items: {ex.Message}");
                return new List<CartItem>();
            }
        }

        public async Task AddToCartAsync(int productId, int quantity = 1)
        {
            try
            {

                await using var context = await _dbContextFactory.CreateDbContextAsync();
                var producto = await context.Productos.FindAsync(productId);

                if (producto == null || producto.Stock <= 0)
                {
                    throw new InvalidOperationException("Producto no disponible");
                }

                var cartJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", CART_KEY);
                var cartData = new Dictionary<int, int>();

                if (!string.IsNullOrEmpty(cartJson))
                {
                    cartData = JsonSerializer.Deserialize<Dictionary<int, int>>(cartJson) ?? new();
                }

                if (cartData.ContainsKey(productId))
                {
                    var newQuantity = cartData[productId] + quantity;
                    if (newQuantity <= producto.Stock)
                    {
                        cartData[productId] = newQuantity;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Stock insuficiente. Disponible: {producto.Stock}");
                    }
                }
                else
                {
                    if (quantity <= producto.Stock)
                    {
                        cartData[productId] = quantity;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Stock insuficiente. Disponible: {producto.Stock}");
                    }
                }

                var newCartJson = JsonSerializer.Serialize(cartData);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", CART_KEY, newCartJson);

                OnCartChanged?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding to cart: {ex.Message}");
                throw;
            }
        }

        public async Task RemoveFromCartAsync(int productId)
        {
            try
            {
                var cartJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", CART_KEY);

                if (string.IsNullOrEmpty(cartJson))
                    return;

                var cartData = JsonSerializer.Deserialize<Dictionary<int, int>>(cartJson) ?? new();

                if (cartData.ContainsKey(productId))
                {
                    cartData.Remove(productId);

                    var newCartJson = JsonSerializer.Serialize(cartData);
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", CART_KEY, newCartJson);

                    OnCartChanged?.Invoke();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing from cart: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateQuantityAsync(int productId, int quantity)
        {
            try
            {
                if (quantity <= 0)
                {
                    await RemoveFromCartAsync(productId);
                    return;
                }

                await using var context = await _dbContextFactory.CreateDbContextAsync();
                var producto = await context.Productos.FindAsync(productId);

                if (producto == null)
                {
                    throw new InvalidOperationException("Producto no encontrado");
                }

                if (quantity > producto.Stock)
                {
                    throw new InvalidOperationException($"Stock insuficiente. Disponible: {producto.Stock}");
                }

                var cartJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", CART_KEY);
                var cartData = new Dictionary<int, int>();

                if (!string.IsNullOrEmpty(cartJson))
                {
                    cartData = JsonSerializer.Deserialize<Dictionary<int, int>>(cartJson) ?? new();
                }

                cartData[productId] = quantity;

                var newCartJson = JsonSerializer.Serialize(cartData);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", CART_KEY, newCartJson);

                OnCartChanged?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating quantity: {ex.Message}");
                throw;
            }
        }

        public async Task ClearCartAsync()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", CART_KEY);
                OnCartChanged?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing cart: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetCartCountAsync()
        {
            try
            {
                var items = await GetCartItemsAsync();
                return items.Sum(item => item.Quantity);
            }
            catch
            {
                return 0;
            }
        }

        public async Task<decimal> GetCartTotalAsync()
        {
            try
            {
                var items = await GetCartItemsAsync();
                return items.Sum(item => item.Product.Precio * item.Quantity);
            }
            catch
            {
                return 0;
            }
        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Producto Product { get; set; } = new();

        public decimal SubTotal => Product.Precio * Quantity;
        public bool IsAvailable => Product.Stock >= Quantity;
        public int MaxQuantity => Product.Stock;
    }

    public class CartSummary
    {
        public List<CartItem> Items { get; set; } = new();
        public int TotalItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Total { get; set; }
        public bool QualifiesForFreeShipping { get; set; }
        public decimal AmountForFreeShipping { get; set; }

        public static CartSummary Calculate(List<CartItem> items, decimal freeShippingThreshold = 50m, decimal standardShipping = 5.99m)
        {
            var subtotal = items.Sum(i => i.SubTotal);
            var totalItems = items.Sum(i => i.Quantity);
            var qualifiesForFreeShipping = subtotal >= freeShippingThreshold;
            var shippingCost = qualifiesForFreeShipping ? 0 : standardShipping;
            var total = subtotal + shippingCost;

            return new CartSummary
            {
                Items = items,
                TotalItems = totalItems,
                Subtotal = subtotal,
                ShippingCost = shippingCost,
                Total = total,
                QualifiesForFreeShipping = qualifiesForFreeShipping,
                AmountForFreeShipping = qualifiesForFreeShipping ? 0 : freeShippingThreshold - subtotal
            };
        }
    }

    public static class CartServiceExtensions
    {
        public static IServiceCollection AddCartService(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
            return services;
        }
    }
}