using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    public class USDollarBill : USBankNote
    {
        public USDollarBill()
        {
            this.Name = "US Dollar Bill";
            this.MonetaryValue = 1.0M;
        }
    }
}