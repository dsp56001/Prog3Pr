using Currency.US;
using Currency;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCurrencyCore8.ViewModels;
using Currency.UK;

namespace WebApplicationCurrencyCore8.Controllers
{
    public class CurrencyController : Controller
    {
        ICurrencyRepo repo { get; set; }
        CurrencyRepoViewModel vm { get; set; }

        public CurrencyController()
        {
            repo = new USCurrencyRepo();
            vm = new CurrencyRepoViewModel(repo);
        }

        private void UKRepo()
        {

        }

        public IActionResult Index(int Locale)
        {
            if (Locale == 1)
            {
                repo = new UKCurrencyRepo();
                vm = new CurrencyRepoViewModel(repo);
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
