using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Injection;

namespace NinjectDemo.UnityContainers
{
    public static class UnityBootstrap
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            //Will inject a sword whenever an IWeapon is needed
            container.RegisterType<IWeapon, Sword>();
            //Will inject Katana in to Samurai
            container.RegisterType<Samurai>(new InjectionConstructor(new Katana()));
        }
    }
}
