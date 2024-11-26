using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationDog.Models.Warrior
{
    public interface IWarrior
    {
        string Name { get; }
        IWeapon Weapon { get; }
        string Attack(string target);
    }
}
