using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public abstract class USCoin : Coin
    {

        public USCoinMintMark MintMark  { get; set; }

        public USCoin()
        {
            this.MintMark = USCoinMintMark.D;
        }

        public USCoin(USCoinMintMark MintMark)
        {
            this.MintMark = MintMark;
        }

        protected USCoin(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        /// <summary>
        /// Tells informatrion about  a US Coin
        /// </summary>
        /// <returns></returns>
        public override string About()
        {
            string strAbout = "";
            strAbout += string.Format("{0}. It was made in {1}",
                base.About(),
                USCoin.GetMintNameFromMark(this.MintMark)
            );
            return "US " + strAbout;
        }

        /// <summary>
        /// Returns the full name of a coind Mint Mark
        /// </summary>
        /// <param name="MintMark"></param>
        /// <returns>Full Mint Namt</returns>
        public static string GetMintNameFromMark(USCoinMintMark MintMark)
        {
            string MintName = "";
            switch (MintMark)
            {

                case USCoinMintMark.P:
                    MintName = "Philadephia";
                    break;
                case USCoinMintMark.D:
                    MintName = "Denver";
                    break;
                case USCoinMintMark.S:
                    MintName = "San Francisco";
                    break;
                case USCoinMintMark.W:
                    MintName = "West Point";
                    break;

            }
            return MintName;
        }


        public static List<ICoin> GetUSCoinList()
        {
            ICoin n = new Nickel();
            ICoin pen = new Penny();
            ICoin q = new Quarter();
            ICoin d = new Dime();
            ICoin hd = new HalfDollar();
            ICoin doll = new DollarCoin();

            List<ICoin> coinList = new List<ICoin>
            {
                { doll },
                { hd },
                { q },
                { d },
                { n },
                { pen }
            };
            return coinList.OrderByDescending(c => c.MonetaryValue).ToList();

        }


    }

    public enum USCoinMintMark
    {
        P, D, S, W
    }
}
