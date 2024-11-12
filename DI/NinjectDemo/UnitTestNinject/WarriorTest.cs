using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NinjectDemo;

namespace UnitTestNinject
{
    [TestClass]
    public class WarriorTest
    {
        [TestMethod]
        public void SamuraiNoInject()
        {
            //Arrange
            Weapon weapon; ;
            Warrior warrior;
            string target;

            //Act 
            weapon = new Katana();
            warrior = new Samurai(weapon); //Dependency Samuria gets Katana
            target = "target";

            //Assert
            Assert.IsInstanceOfType(warrior, typeof(Warrior));
            Assert.IsInstanceOfType(warrior, typeof(Samurai));
            Assert.IsInstanceOfType(warrior.Weapon, typeof(Katana));
            Assert.AreEqual($"{warrior.ToString()} uses {warrior.Weapon.Name} on {target}", warrior.Attack(target));
        }

        [TestMethod]
        public void NinjaNoInject()
        {
            //Arrange
            Weapon weapon;
            Warrior warrior;
            string target;

            //Act 
            weapon = new Sword();
            warrior = new Samurai(weapon); //Dependency Ninja gets sword
            target = "target";

            //Assert
            Assert.IsInstanceOfType(warrior, typeof(Warrior));
            Assert.IsInstanceOfType(warrior, typeof(Samurai));
            Assert.IsInstanceOfType(warrior.Weapon, typeof(Sword));
            Assert.AreEqual($"{warrior.ToString()} uses {warrior.Weapon.Name} on {target}", warrior.Attack(target));
        }
    }
}
