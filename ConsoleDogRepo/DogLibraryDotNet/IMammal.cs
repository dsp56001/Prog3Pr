using DogLibrary;
using DogLibraryDotNet.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogLibrary
{
    public interface  IMammal : IAboutable, IEntity
    {
        int Age { get; }
        string Name { get; set; }
        string Sound { get; }
        int Weight { get; }

        string MakeSound();
        int HappyBirthday();
        void Eat();
    }

    public interface IAboutable
    {
        string About();
    }
}