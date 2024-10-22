using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfAppDog.Models;
using DogLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using WpfAppDog.ViewModels;
using WpfAppDogDepend;

namespace UnitTestWpfDog
{
    [TestClass]
    public class ViewModelMammalTest
    {
        ViewModelMammal wpfMammal;

        public ViewModelMammalTest()
        {
            wpfMammal = new ViewModelMammal(new Dog());
        }

        [TestMethod]
        public void TestHappyBirthDay()
        {
            //Arrange
            int Age = wpfMammal.Age;
            int AgeAfterHappyBirthday = 0;
            List<string> receivedEvents = new List<string>();

            wpfMammal.PropertyChanged += delegate (object ?sender, PropertyChangedEventArgs e)
            {

                if (e.PropertyName == null)
                {
                    Assert.Fail("Property Name is null");
                }
                receivedEvents.Add(e.PropertyName);
            };

            //Act
            wpfMammal.HappyBirthday.Execute(null);
            AgeAfterHappyBirthday = wpfMammal.Age;
            //Assert
            Assert.AreEqual(Age + 1, AgeAfterHappyBirthday);
            Assert.AreEqual(receivedEvents[0], "Age");
        }

        [TestMethod]
        public void TestDependencyProperties()
        {
            //Arrange

            ViewModelMammal vm;
            IMammal dog;

            //Act 
            dog = new Dog();
            vm = new ViewModelMammal(dog);

            string dogNamePrev = dog.Name;
            string vmNamePres = vm.Name;

            bool gotEvent = false;

            ((INotifyPropertyChanged)vm).PropertyChanged +=
                delegate (object ?sender, PropertyChangedEventArgs e)
                {
                    gotEvent = true;
                    if(e.PropertyName == null)
                    {
                        Assert.Fail("Property Name is null");
                    }
                    Assert.AreEqual<string>("Name", e.PropertyName);
                };

            string newValue = "NewName";
            vm.Name = newValue;

            Assert.AreEqual<string>(newValue, vm.Name, "View Model Changed");

            //Assert
            Assert.IsInstanceOfType(vm, typeof(INotifyPropertyChanged));
            Assert.IsTrue(gotEvent, "Didn’t get the PropertyChanged event.");
        }

        [TestMethod]
        public void TestObservableCollection()
        {
            //Arrange
            ViewModelMammals vm;


            //Act 
            vm = new ViewModelMammals(App.mammals);
            


            //Assert
        }
    }
}
