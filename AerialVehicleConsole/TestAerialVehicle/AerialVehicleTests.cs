using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPFlyingVehicle;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class AerialVehicleTests
    {

        //[TestMethod]
        //[ExpectedException(typeof(MissingMethodException), "Cannot create an abstract class.")] //Since it's abstact it doesn't have constructor it will throw a MissingMethodException 
        
        //public void AerialVehicleAstract_Throws()
        //{
        //    var ae = Activator.CreateInstance<AerialVehicle>(); //Will throw
        //}

        [TestMethod]
        //TODO Too many tests one method not named well enough should break this up
        public void AerialVehicleEngineTests()
        {
            //Arrange
            Airplane ap = new Airplane();
            //Act 
            bool defaultEngine = ap.Engine.IsStarted;  //default should be off
            ap.StartEngine();
            bool startedEngine = ap.Engine.IsStarted;
            ap.StopEngine();
            bool stoppedEngine = ap.Engine.IsStarted;

            //Assert
            Assert.IsFalse(defaultEngine); // default is stopped
            Assert.IsTrue(startedEngine); // after start is called engine should be stated
            Assert.IsFalse(stoppedEngine); // after stop is called engine should be stopped
        }
    }
}
