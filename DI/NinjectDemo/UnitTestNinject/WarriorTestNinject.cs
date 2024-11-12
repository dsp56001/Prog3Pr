using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using NinjectDemo;
using NinjectDemo.NinjectModules;

namespace UnitTestNinject
{
    [TestClass]
    public class WarriorTestNinject
    {
        IKernel kernel;

        public WarriorTestNinject()
        {
            kernel = new StandardKernel(new WarriorModule());
        }

        [TestMethod]
        public void SamuriaNinjectModule()
        {
            //Arrange
            Warrior warrior;
            string target;

            //Act 
            warrior = kernel.Get<Samurai>(); 
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
            warrior = kernel.Get<Ninja>();
            target = "target";

            //Assert
            Assert.IsInstanceOfType(warrior, typeof(Warrior));
            Assert.IsInstanceOfType(warrior, typeof(Ninja));
            Assert.IsInstanceOfType(warrior.Weapon, typeof(Sword));
            Assert.AreEqual($"{warrior.ToString()} uses {warrior.Weapon.Name} on {target}", warrior.Attack(target));
        }
    }
}
