using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationTest.Controllers;

namespace WebApplicationTest.Models
{
    public class HelloNinectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHello>().To<TestHello>();
        }
    }
}