using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    public class TestController : Controller
    {

        public IHello hello { get; set; }

        public TestController(IHello hello)
        {
            this.hello = hello;
        }
        
        // GET: Test
        public ActionResult Index()
        {
            
            
            return View(hello);
        }
    }
}