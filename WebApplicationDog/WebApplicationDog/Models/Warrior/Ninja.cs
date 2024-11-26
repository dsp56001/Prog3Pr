using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationDog.Models.Warrior
{
    public class Ninja : Warrior
    {
        public Ninja(IWeapon weapon) : base(weapon)
        {
            this.Name = "Ninja";
        }
    }
}
