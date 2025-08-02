using KeyStore.Components;
using KeyStore.Components.Account;
using KeyStore.Data;
using KeyStore.DAL;
using KeyStore.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContextFactory<Contexto>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<AuthStateService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.FromSeconds(10); 
    options.OnRefreshingPrincipal = context =>
    {
        return Task.CompletedTask;
    };
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";

    options.Events.OnSigningOut = async context =>
    {
        context.Response.Cookies.Delete(options.Cookie.Name);
        context.Response.Cookies.Delete(".AspNetCore.Identity.Application");
    };

    options.Events.OnValidatePrincipal = async context =>
    {
        var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
        var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<ApplicationUser>>();

        if (context.Principal?.Identity?.IsAuthenticated == true)
        {
            var user = await userManager.GetUserAsync(context.Principal);
            if (user == null)
            {
                context.RejectPrincipal();
                await signInManager.SignOutAsync();
            }
        }
    };
});

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddScoped<IProductosService, ProductosServiceMock>();
builder.Services.AddHttpClient<ProductosService>();
builder.Services.AddCartService();

builder.Services.AddScoped<IImagenService, ImagenService>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<SeedData>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();

    using var scope = app.Services.CreateScope();

    var identityContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    identityContext.Database.Migrate();

    var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<Contexto>>();
    using var appContext = contextFactory.CreateDbContext();
    appContext.Database.Migrate();

    var seedData = scope.ServiceProvider.GetRequiredService<SeedData>();
    await seedData.Initialize();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// CORS
app.UseCors();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();
app.MapControllers();

app.Run();