using Currency;
using Currency.US;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCurrencyCore31.ViewModels;

namespace WebApplicationCurrencyCore31.Controllers
{
    public class CurrencyController : Controller
    {
        ICurrencyRepo repo { get; set; }
        RepoViewModel vm { get; set; }

        public CurrencyController()
        {
            repo = new USCurrencyRepo();
            vm = new RepoViewModel(repo);
        }

        // GET: CurrencyRepo
        public ActionResult Index()
        {

            return View(vm);
        }

        // GET: CurrencyRepo
        public ActionResult MakeChange(Double Amount)
        {
            vm.MakeChange(Amount);
            return View(vm);
        }
    }
}
