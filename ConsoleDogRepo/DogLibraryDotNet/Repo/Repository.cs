using System;
using System.Collections.Generic;
using System.Text;

namespace DogLibraryDotNet.Repo
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        List<T> _repo;

        public Repository()
        {
            _repo = new List<T>();
        }
        public virtual T GetById(int id)
        {
            var result = _repo.FirstOrDefault(e => e.Id == id);
            if (result == null)
            {
                throw new Exception("Entity not found");
            }
            return result;
        }
        public virtual IEnumerable<T> List()
        {
            return _repo;
        }

        public virtual void Add(T entity)
        {
            _repo.Add(entity);

        }
        public virtual void Remove(T entity)
        {
            _repo.Add(entity);

        }
        
    }
}
