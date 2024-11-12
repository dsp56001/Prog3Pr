using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using NinjectDemo;
using NinjectDemo.UnityContainers;
using Unity;

namespace UnitTestNinject
{
    [TestClass]
    public class WarriorTestUnity
    {
        // Declare a Unity Container
        IUnityContainer unityContainer;

        public WarriorTestUnity()
        {
            //set up unity container
            unityContainer = new UnityContainer();
            UnityBootstrap.RegisterTypes(unityContainer);
        }

        [TestMethod]
        public void SamuriaUnityModule()
        {
            //Arrange
            Warrior warrior;
            string target;

            //Act 
            warrior = unityContainer.Resolve<Samurai>();
            target = "target";

            //Assert
            Assert.IsInstanceOfType(warrior, typeof(Warrior));
            Assert.IsInstanceOfType(warrior, typeof(Samurai));
            Assert.IsInstanceOfType(warrior.Weapon, typeof(Katana));
            Assert.AreEqual($"{warrior.ToString()} uses {warrior.Weapon.Name} on {target}", warrior.Attack(target));
        }

        [TestMethod]
        public void NinjaNinjectModule()
        {
            //Arrange
            Warrior warrior;
            string target;

            //Act 
            warrior = unityContainer.Resolve<Ninja>();
            target = "target";

            //Assert
            Assert.IsInstanceOfType(warrior, typeof(Warrior));
            Assert.IsInstanceOfType(warrior, typeof(Ninja));
            Assert.IsInstanceOfType(warrior.Weapon, typeof(Sword));
            Assert.AreEqual($"{warrior.ToString()} uses {warrior.Weapon.Name} on {target}", warrior.Attack(target));
        }
    }
}
