using System;
using DogLibrary;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfAppDog.Models;
using WpfAppDog.ViewModels;
using WpfAppDogDepend;

namespace UnitTestWpfDog
{
    [TestClass]
    public class ViewModelMammalsTests
    {

        ViewModelMammals vmMammals;

        public ViewModelMammalsTests()
        {
            vmMammals = new ViewModelMammals(App.mammals);
        }

        [TestMethod]
        public void DefaultMammalTests()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void LoadMammalsTests()
        {
            //Arrange
            var expectedMammals = new ObservableCollection<ViewModelMammal>()
                {
                    new ViewModelMammal ( new Dog{ BarkSound="woof!", Name="fido"}),
                    new ViewModelMammal ( new Dog{ BarkSound="arf!", Name="rover"}),
                    new ViewModelMammal ( new Dog{ BarkSound="arf!", Name="milo"}),
                    new ViewModelMammal ( new Dog{ BarkSound="arf!", Name="spot"})
                };

            //Act
            vmMammals.LoadMammals();
            var mammals = vmMammals.Mammals;

            //Assert
            Assert.IsInstanceOfType(mammals, typeof(ObservableCollection<ViewModelMammal>));
            for (int i = 0; i < mammals.Count; i++)
            {
                Assert.AreEqual(expectedMammals[i].Name, mammals[i].Name);
            }
        }
    }
}
