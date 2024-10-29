using System;
using System.Collections.Generic;
using System.Text;

namespace DogLibraryDotNet.Repo
{
    public interface IEntity
    {
        int Id { get; }
    }

    public abstract class EntityBase : IEntity
    {
        public int Id { get; protected set; }
    }
}
