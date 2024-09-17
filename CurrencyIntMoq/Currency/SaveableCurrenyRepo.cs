using Currency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    [Serializable]
    public class SaveableCurrenyRepo : CurrencyRepo, ISerializable
    {

        public string FileSavePath { get; set; }


        public SaveableCurrenyRepo() : this(new List<ICoin>())
        {

        }

        public SaveableCurrenyRepo(List<ICoin> coins) : base(coins)
        {
            Path = "MyFile.bin";
        }

        public string Path { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            if (Path == null)
            {
                return false;
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(this.Path,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.Coins);
            stream.Close();
            return true;
        }

        public ICollection<ICoin> Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            List<ICoin> coins = (List<ICoin>)formatter.Deserialize(stream);
            stream.Close();
            return coins;
        }
    }
}
