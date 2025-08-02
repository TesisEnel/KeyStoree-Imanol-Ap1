using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using KeyStore.Data;
using System.Security.Claims;
using KeyStore.Components.Account;

namespace KeyStore.Services
{
    public class AuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            NavigationManager navigationManager,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _navigationManager = navigationManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<SignInResult> Login(string email, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(
                email, password, rememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                await ForceAuthenticationStateUpdate();
                _navigationManager.NavigateTo("/perfil", forceLoad: true);
            }

            return result;
        }

        public async Task<IdentityResult> Register(string email, string password, string fullName)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                NombreCompleto = fullName,
                EmailConfirmed = true 
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Cliente");
                await _signInManager.SignInAsync(user, isPersistent: false);

                await ForceAuthenticationStateUpdate();
                _navigationManager.NavigateTo("/perfil", forceLoad: true);
            }

            return result;
        }

        public async Task Logout()
        {
            try
            {
                Console.WriteLine("🔄 AuthService: Iniciando logout...");

                await _signInManager.SignOutAsync();
                Console.WriteLine("✅ SignOut completado");

                await ForceAuthenticationStateUpdate();

                await Task.Delay(100);

                Console.WriteLine("🔄 Redirigiendo al home...");

                _navigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en logout: {ex.Message}");

                _navigationManager.NavigateTo("/", forceLoad: true);
            }
        }

        private async Task ForceAuthenticationStateUpdate()
        {
            try
            {
                if (_authenticationStateProvider is IdentityRevalidatingAuthenticationStateProvider revalidatingProvider)
                {

                    var method = revalidatingProvider.GetType().GetMethod("ValidateAuthenticationStateAsync",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                    if (method != null)
                    {
                        await (Task)method.Invoke(revalidatingProvider, new object[] { CancellationToken.None });
                        Console.WriteLine("✅ Estado de autenticación forzado a revalidar");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ No se pudo forzar revalidación: {ex.Message}");
            }
        }

        public async Task<bool> IsUserInRole(ApplicationUser user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<IList<string>> GetUserRoles(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}