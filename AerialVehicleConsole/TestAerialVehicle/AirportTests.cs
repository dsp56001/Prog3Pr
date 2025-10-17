using System;
using OOPFlyingVehicle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class AirportTests
    {
        /// <summary>
        /// Write some airpost tests
        /// </summary>
        [TestMethod]
        public void AirPortConstructor()
        {
            //Arrange
            int defaultMaxVehicles;
            int JFKMaxVehicles;
            //Act
            defaultMaxVehicles = 5;
            JFKMaxVehicles = 10;
            Airport apORD = new Airport("ORD");
            Airport apJFK = new Airport("JFK", JFKMaxVehicles);
            //Assert
            Assert.AreEqual(defaultMaxVehicles, apORD.MaxVehicles);
            Assert.AreEqual(JFKMaxVehicles, apJFK.MaxVehicles);
            Assert.IsInstanceOfType(apORD.Vehicles, typeof(List<AerialVehicle>));
        }



        [TestMethod]
        public void AirPortLandSingle()
        {
            //Arrange
            Airport apORD = new Airport("ORD");
            Airplane plane = new Airplane();
            int orginalCount;
            //Act
            orginalCount = apORD.Vehicles.Count;
            apORD.Land(plane);
            //Assert
            Assert.HasCount(orginalCount + 1, apORD.Vehicles);
        }

        [TestMethod]
        public void AirPortLandListMultipleBelowMax()
        {
            //Arrange
            Airport apORD = new Airport("ORD");
            Airplane plane = new Airplane();
            int MaxVehicles;
            AerialVehicle[] planes;
            int orginalCount;
            //Act
            MaxVehicles = apORD.MaxVehicles;
            orginalCount = apORD.Vehicles.Count;
            planes = new AerialVehicle[MaxVehicles];
            for (int i = 0; i < MaxVehicles; i++)
            {
                planes[i] = new Airplane();
            }
            apORD.Land(planes.ToList());
            //Assert
            Assert.HasCount(orginalCount + MaxVehicles, apORD.Vehicles);
        }

        [TestMethod]
        public void AirPortLandListMultipleAboveMax()
        {
            //Arrange
            Airport apORD = new Airport("ORD");
            Airplane plane = new Airplane();
            int MaxVehicles;
            AerialVehicle[] planes;
            int orginalCount;
            //Act
            MaxVehicles = apORD.MaxVehicles + 1; //One more than allowed
            orginalCount = apORD.Vehicles.Count;
            planes = new AerialVehicle[MaxVehicles];
            for (int i = 0; i < MaxVehicles; i++)
            {
                planes[i] = new Airplane();
            }
            apORD.Land(planes.ToList());
            //Assert
            Assert.HasCount(apORD.MaxVehicles, apORD.Vehicles);
        }

        [TestMethod]
        public void AllTakeOff()
        {
            //Arrange
            Airport apORD = new Airport("ORD");
            int MaxVehicles = apORD.MaxVehicles;
            AerialVehicle[] planes;
            AerialVehicle[] preTakeOff, afterAllTakeOff;
            //Act
            planes = new AerialVehicle[MaxVehicles];
            for (int i = 0; i < MaxVehicles; i++)
            {
                planes[i] = new Airplane();
            }

            apORD.Land(planes.ToList());

            preTakeOff = new AerialVehicle[MaxVehicles];
            afterAllTakeOff = new AerialVehicle[MaxVehicles];
            apORD.Vehicles.CopyTo(preTakeOff);
            apORD.AllTakeOff();
            apORD.Vehicles.CopyTo(afterAllTakeOff);
            //Assert
            CollectionAssert.AreEqual(planes, preTakeOff);

        }
    }
}
