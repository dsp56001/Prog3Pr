using Microsoft.Extensions.DependencyInjection;
using Microsoft.Testing.Platform.Configurations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NinjectDemo;
using NinjectDemo.MEDependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace UnitTestNinject
{
    [TestClass]
    public class WarriorTestMSDI
    {

        

        WarriorService ws;


        public WarriorTestMSDI()
        {
            ws = new WarriorService();
        }   


        [TestMethod]
        public void WarriorsMSDI()
        {

            //Arrange
            Warrior warrior;
            string target;

            //Act 
            warrior = ws.ServiceProvider.GetService<Samurai>();
            target = "target";

            //Assert
            Assert.IsInstanceOfType(warrior, typeof(Warrior));
            Assert.IsInstanceOfType(warrior, typeof(Samurai));
            Assert.IsInstanceOfType(warrior.Weapon, typeof(Katana));
            Assert.AreEqual($"{warrior.ToString()} uses {warrior.Weapon.Name} on {target}", warrior.Attack(target));

            //Arrange 

            //Act 

            //Assert



        }

    }
}

