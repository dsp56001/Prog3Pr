using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DogLibraryDotNet.Repo
{
    public interface IRepository<T> //where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        void Add(T entity);
        void Remove(T entity);
    }
}
