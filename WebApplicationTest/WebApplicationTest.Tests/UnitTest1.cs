using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationTest.Controllers;
using WebApplicationTest.Models;
using System.Web.Mvc;

namespace WebApplicationTest.Tests
{
    [TestClass]
    public class UnitTest_TestController
    {
       

        IHello hello;

        [TestMethod]
        public void TestController_Index()
        {
            //Arrange 
            var controller = new TestController(hello);

            //Act
            ViewResult result = controller.Index() as ViewResult;
            var model = (TestHello)result.Model;

            //Assert
            Assert.AreEqual(model.Hello, "Hello");
        }
    }
}
