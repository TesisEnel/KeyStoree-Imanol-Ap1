using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KeyStore.Data
{
    public class SeedData
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            try
            {
                Console.WriteLine("Iniciando SeedData...");

                await EnsureRolesCreated();

                await EnsureAdminUserExists();

                await EnsureTestClientExists();

                Console.WriteLine("SeedData completado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inicializar datos: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        private async Task EnsureRolesCreated()
        {
            string[] roleNames = { "Admin", "Cliente", "Vendedor" };

            foreach (var roleName in roleNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                    Console.WriteLine($"Rol '{roleName}' creado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"Rol '{roleName}' ya existe.");
                }
            }
        }

        private async Task EnsureAdminUserExists()
        {
            var adminEmail = "admin@keystore.com";
            var adminPassword = "Admin123!";

            var adminUser = await _userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    Nombre = "Administrador",
                    Apellido = "Sistema",
                    NombreCompleto = "Administrador Sistema",
                    FechaRegistro = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                    Console.WriteLine($"Usuario admin '{adminEmail}' creado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"Error al crear usuario admin: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                Console.WriteLine($"Usuario admin '{adminEmail}' ya existe.");
            }
        }

        private async Task EnsureTestClientExists()
        {
            var clientEmail = "cliente@keystore.com";
            var clientPassword = "Cliente123!";

            var clientUser = await _userManager.FindByEmailAsync(clientEmail);

            if (clientUser == null)
            {
                clientUser = new ApplicationUser
                {
                    UserName = clientEmail,
                    Email = clientEmail,
                    EmailConfirmed = true,
                    Nombre = "Cliente",
                    Apellido = "Prueba",
                    NombreCompleto = "Cliente de Prueba",
                    FechaRegistro = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(clientUser, clientPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(clientUser, "Cliente");
                    Console.WriteLine($"Usuario cliente '{clientEmail}' creado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"Error al crear usuario cliente: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                Console.WriteLine($"Usuario cliente '{clientEmail}' ya existe.");
            }
        }
    }
}