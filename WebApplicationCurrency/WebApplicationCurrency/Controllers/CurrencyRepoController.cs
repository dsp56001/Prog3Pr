using Currency;
using Currency.US;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationCurrency.Models;

namespace WebApplicationCurrency.Controllers
{
    public class CurrencyRepoController : Controller
    {

        ICurrencyRepo repo { get; set; }
        RepoViewModel vm { get { return new RepoViewModel(repo); } } 

        public CurrencyRepoController()
        {
            //repo = new USCurrencyRepo();
            //vm = new RepoViewModel(repo);
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