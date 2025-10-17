using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPFlyingVehicle;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void EngineIsStarted()
        {
            //Arrange
            Engine e = new Engine();
            //Act 
            bool defaultEngineStarted = e.IsStarted;
            e.Start();
            bool startEngineStarted = e.IsStarted;
            e.Stop();
            bool stopEngineStarted = e.IsStarted;
            //Assert
            Assert.IsFalse(defaultEngineStarted);
            Assert.IsTrue(startEngineStarted);
            Assert.IsFalse(stopEngineStarted);
        }

        [TestMethod]
        public void EngineAbout()
        {
            //Arrange
            Engine e = new Engine();
            //Act 
            string defaultEngineAbout = e.About();
            e.Start();
            string startedAbout = e.About();
            e.Stop();
            string stoppedAbout = e.About();
            //Assert
            Assert.AreEqual(defaultEngineAbout, $"{e.ToString()} is not started.");
            Assert.AreEqual(startedAbout, $"{e.ToString()} is started.");
            Assert.AreEqual(stoppedAbout, $"{e.ToString()} is not started.");
        }
    }
}
