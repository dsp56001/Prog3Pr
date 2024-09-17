using Currency;
using Currency.US;
using Currency.UK;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCurrencyCore6.ViewModels;

namespace WebApplicationCurrencyCore6.Controllers
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

       
        private void UKRepo()
        {
            
        }

        public IActionResult Index(int Locale)
        {
            if(Locale == 1)
            {
                repo = new UKCurrencyRepo();
                vm = new RepoViewModel(repo);
            }

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
