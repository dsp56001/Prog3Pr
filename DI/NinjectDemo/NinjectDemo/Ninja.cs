using System;
using System.Collections.Generic;
using System.Text;

namespace NinjectDemo
{
    public class Ninja : Warrior
    {
        public Ninja(IWeapon weapon) : base(weapon)
        {

        }
    }
}
