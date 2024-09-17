using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using WebApplicationTest.Models;

namespace WebApplicationTest
{
    public class MvcApplication : NinjectHttpApplication
    {
        

        protected  override void OnApplicationStarted()
        {
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new HelloNinectModule());
        }
    }
}
