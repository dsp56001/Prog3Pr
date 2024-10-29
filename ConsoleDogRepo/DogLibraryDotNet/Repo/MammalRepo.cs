using DogLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DogLibraryDotNet.Repo
{
    public class MammalRepo : IRepository<IMammal>
    {
        List<IMammal> _repo;

        public MammalRepo() : base()
        {
            _repo = new List<IMammal>();
        }

        public void Add(IMammal entity)
        {
            this._repo.Add(entity);
        }

        public IMammal GetById(int id)
        {
            var result = _repo.FirstOrDefault(m => m.Id == id);
            if (result == null)
            {
                throw new Exception("Mammal not found");
            }
            return result;
        }

        public IEnumerable<IMammal> List()
        {
            return this._repo;
        }

        public void Remove(IMammal entity)
        {
            this._repo.Remove(entity);
        }

        public IMammal? GetMammalByName(string findName)
        {
            return this._repo.Where(m => m.Name == findName).FirstOrDefault();
        }

        public IMammal? GetMammalByWeight(int findWeight)
        {
            return this._repo.Where(m => m.Weight == findWeight).FirstOrDefault();
        }
    }
}
