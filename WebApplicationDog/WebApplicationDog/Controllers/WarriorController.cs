using Microsoft.AspNetCore.Mvc;
using WebApplicationDog.Models.Warrior;

namespace WebApplicationDog.Controllers
{
    public class WarriorController : Controller
    {
        IWarrior warrior;

        public WarriorController(IWarrior warrior)
        {
            this.warrior = warrior;
        }

        public IActionResult Index()
        {
            return View(warrior);
        }
    }
}
