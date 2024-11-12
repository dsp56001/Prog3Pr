using System;
using System.Collections.Generic;
using System.Text;

namespace NinjectDemo
{
    public class Samurai : Warrior
    {
        public Samurai(IWeapon weapon) : base(weapon)
        {

        }
    }
}
