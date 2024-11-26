using Microsoft.Extensions.DependencyInjection;
using WebApplicationDog.Models.Mammals;
using WebApplicationDog.Models.Scope;
using WebApplicationDog.Models.Warrior;

namespace WebApplicationDog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // Register the services
            //Mammal
            builder.Services.AddSingleton<IMammal, Cat>();

            //Warrior
            builder.Services.AddScoped<Samurai>().AddScoped<IWeapon, Katana>();
            builder.Services.AddScoped<Ninja>().AddScoped<IWeapon, Sword>();
            builder.Services.AddScoped<IWeapon, Katana>();
            builder.Services.AddScoped<Warrior, Samurai>();
            builder.Services.AddScoped<IWarrior, Samurai>();

            //Scoped Demo
            builder.Services.AddTransient<ITransientService, OperationService>();
            builder.Services.AddScoped<IScopedService, OperationService>();
            builder.Services.AddSingleton<ISingletonService, OperationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
