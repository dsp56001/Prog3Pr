using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorLibrary.MSEDI
{
    class WarriorService
    {

        IServiceCollection serviceCollection;
        serviceCollection = new ServiceCollection();

        su.ConfigureServices(serviceCollection);

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Dog binding test inject a dog if anyone needs one
            services.AddSingleton<IDog, Dog>();

            //Weapons the default weapon is a Katana
            services.AddScoped<IWeapon, Katana>();
            services.AddScoped<Weapon, Katana>();

            //The Default Warrior is a Samurai
            services.AddScoped<IWarrior, Samurai>();
            services.AddScoped<Warrior, Samurai>();

            services.AddControllersWithViews();

        }
    }
}
