﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationDog.Models.Warrior
{
    public abstract class Weapon : IWeapon
    {
        protected string name;
        public string Name => name;

        public Weapon()
        {
            name = "Weapon";
        }

        public string Hit(string target)
        {
            return $"{this.Name} on {target}";
        }
    }
}
