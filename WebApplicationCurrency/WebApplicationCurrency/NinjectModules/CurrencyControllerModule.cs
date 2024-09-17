using Currency;
using Currency.US;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCurrency.NinjectModules
{
    public class CurrencyControllerModule : NinjectModule

    {
        public override void Load()
        {
            Bind<ICurrencyRepo>().To<USCurrencyRepo>();
        }
    }
}