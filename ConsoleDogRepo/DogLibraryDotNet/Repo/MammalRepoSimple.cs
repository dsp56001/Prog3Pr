using DogLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogLibraryDotNet.Repo
{
    public class MammalRepoSimple
    {
        List<IMammal> Mammals;

        //Empty Constructor
        public MammalRepoSimple()
        {
            Mammals = new List<IMammal>();
        }

        public MammalRepoSimple(List<IMammal> mammals)
        {
            Mammals = mammals;
        }

        public virtual void Add(IMammal Mammal)
        {
            this.Mammals.Add(Mammal);
        }

        public virtual void Remove(IMammal Mammal)
        {
            this.Mammals.Remove(Mammal);
        }

        public virtual IMammal? GetMammalByName(string name)
        {
            foreach (var mam in Mammals)
            {
                if (mam.Name == name)
                    return mam;
            }
            //null object anti pattern
            return null;
        }

        public virtual IMammal? GetMammalByWeight(int weight)
        {
            return Mammals.Where(m => m.Weight == weight).FirstOrDefault();

        }

        public virtual List<IMammal> GetAllMammals()
        {
            return Mammals;
        }
    }
}
