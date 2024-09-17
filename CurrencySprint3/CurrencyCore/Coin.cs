using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Currency
{
    [Serializable]
    public abstract class Coin : ICoin
    {
        
        public int Year { get; set; }
        public double MonetaryValue { get; protected set; }
        //public double  CollectorsValue;
        public string Name { get; protected set; }

        public Coin()
        {
            this.Name = "Coin";
            this.Year = System.DateTime.Now.Year;
            
        }

#region Serializable
        protected Coin(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Year = info.GetInt32("Year");
            MonetaryValue = info.GetDouble("MonetaryValue");

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Adds Data to Serializtion of Dog class
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public virtual void GetObjectData(SerializationInfo info,
            StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Year", Year);
            info.AddValue("MonetaryValue", MonetaryValue);
        }

        /// <summary>
        /// SHows how to compare dogs for equality
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            var toCompareWith = other as Coin;
            if (toCompareWith == null)
                return false;
            return this.Name == toCompareWith.Name &&
                this.MonetaryValue == toCompareWith.MonetaryValue &&
                this.Year == toCompareWith.Year;
        }

        /// <summary>
        /// Must overide this also
        /// </summary>
        /// <returns></returns>
        //public override int GetHashCode()
        //{
        //    return this.GetHashCode();
        //}
        #endregion


        /// <summary>
        /// Tells infomation about a Coin
        /// </summary>
        /// <returns></returns>
        public virtual string About()
        {
            string strAbout = "";
            strAbout += string.Format("{0} is from {1}. It is worth {2}",
                this.Name,
                this.Year,
                
                String.Format("{0:C}",this.MonetaryValue)
            );
            return strAbout;
        }
    }    
}
