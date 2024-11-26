using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApplicationDog.Controllers;
using WebApplicationDog.Models.Mammals;

using Microsoft.AspNetCore.Builder;

namespace TestProjectWebDog
{
    [TestClass]
    public class DogControllerTests
    {
        [TestMethod]
        public void DogControllerIndex()
        {
            // Arrange
            IMammal _dog = new Dog();
            var controller = new DogController(_dog); //no injection

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [TestMethod]
        public void DogControllerIndexDI()
        {
            // Arrange
            IMammal _dog = new Dog();
            var controller = new DogController(_dog);

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(_dog.GetType(), result.Model.GetType());
            
        }

        [TestMethod]
        public void ServiceCollectionDI()
        {
            // Arrange
            IServiceCollection serviceCollection;
            serviceCollection = new ServiceCollection();
            var provider = serviceCollection.BuildServiceProvider();
            IMammal? mammal = provider.GetService<IMammal>();
            // Act
            Assert.IsNotNull(mammal);
            var controller = new DogController(mammal);
            var result = (ViewResult)controller.Index();

            // Assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            
        }
    }
}