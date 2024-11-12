using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjectDemo.NinjectModules
{
    public class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            //Will inject Sword in to IWeapon 
            this.Bind<IWeapon>().To<Sword>(); 
            //Will inject Katan in to Samurai
            this.Bind<IWeapon>().To<Katana>().WhenInjectedInto<Samurai>(); 

        }
    }
}
