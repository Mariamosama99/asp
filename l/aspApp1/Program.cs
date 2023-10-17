using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Models;
using Repository;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/SignIn";
        });

        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
        })
        .AddEntityFrameworkStores<MyDBContext>();

        builder.Services.AddScoped<MyDBContext>();
        builder.Services.AddScoped<UnitOfWork>();
        builder.Services.AddScoped<ProductManager>();
        builder.Services.AddScoped<CategoryManeger>();
        builder.Services.AddScoped<AccountManger>();
        builder.Services.AddScoped<RoleManager>();
        builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, UserFactory>();
        builder.Services.AddControllersWithViews();


        builder.Services.AddDbContext<MyDBContext>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlServer(
                builder.Configuration.GetConnectionString("MyDB"));
        });


        var app = builder.Build();

        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory() + "/Content"),
            RequestPath = ""
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute("Default", "{controller=Dashboard}/{action=Index}/{id?}");

        app.Run();
    }
}