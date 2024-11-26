using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationDog.Models.Warrior
{
    public class Samurai : Warrior
    {
        public Samurai(IWeapon weapon) : base(weapon)
        {
            this.Name = "Samurai";
        }
    }
}
