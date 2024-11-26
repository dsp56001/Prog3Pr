using System;
using System.Collections.Generic;
using System.Text;


namespace WebApplicationDog.Models.Warrior
{
    public interface IWeapon
    {
        string Name { get; }
        string Hit(string target);
    }
}