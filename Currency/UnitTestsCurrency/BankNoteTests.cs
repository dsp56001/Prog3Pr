using Currency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestsCurrency
{
    [TestClass]
    public class BankNoteTests
    {
        [TestMethod]
        [ExpectedException(typeof(MissingMethodException), "Cannot create an abstract class.")] //Since it's abstact it doesn't have constructor it will throw a MissingMethodException 
        public void CointIsAbstract_Throws()
        {
            var ae = Activator.CreateInstance<BankNote>(); //Will throw an exception
        }
    }
}
