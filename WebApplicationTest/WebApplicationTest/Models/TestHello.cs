using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class TestHello : IHello
    {
        protected string hello;

        public string Hello { get => this.hello; set => this.hello = value; }

        public string SayHello()
        {
            return Hello;
        }

        public TestHello()
        {
            Hello = "Hello";
        }
    }
}