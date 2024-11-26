using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationDog.Models.Warrior
{ 
    
    public abstract class Warrior : IWarrior
    {
        protected IWeapon weapon;

        public IWeapon Weapon => weapon;

        public string Name { get; set; }

        public Warrior(IWeapon weapon)
        {
            this.weapon = weapon;
            this.Name = "warrior";
        }

        public string Attack(string target)
        {
            return $"{this} uses {this.weapon.Hit(target)}";
        }
    }
}
