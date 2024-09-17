using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    public abstract class USCoin : Coin
    {

        public USCoinMintMark MintMark  { get; set; }

        public USCoin()
        {
            
        }

        public USCoin(USCoinMintMark MintMark)
        {
            
        }

        /// <summary>
        /// Tells informatrion about  a US Coin
        /// </summary>
        /// <returns></returns>
        public override string About()
        {
            string strAbout = "";
            
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
            
            return MintName;
        }

        public static List<ICoin> GetUSCoinList()
        {

            return null;

        }

    }

    public enum USCoinMintMark
    {
        P, D, S, W
    }
}
