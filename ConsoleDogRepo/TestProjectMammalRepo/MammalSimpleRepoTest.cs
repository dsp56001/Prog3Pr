using DogLibrary;
using DogLibraryDotNet.Repo;

namespace TestProjectMammalRepo
{
    [TestClass]
    public class MammalSimpleRepoTest
    {
        MammalRepoSimple repo = new MammalRepoSimple();

        [TestInitialize]
        public void TestInit()
        {
            //This method runs before each test
            
            repo.Add(new Dog() { Name = "fido", Weight = 10 });
            repo.Add(new Dog() { Name = "milo", Weight = 20 });
        }

        [TestMethod]
        public void TestFindByName()
        {
            //Arrange
            string findName = "fido";
            int findWeight = 20;
            Dog? foundByName, foundByWeight;

            //act
            foundByName = repo.GetMammalByName(findName) as Dog;
            foundByWeight = repo.GetMammalByWeight(findWeight) as Dog;

            //assert
            Assert.IsNotNull(foundByName);
            Assert.AreEqual(findName, foundByName.Name);
            Assert.IsNotNull(foundByWeight);
            Assert.AreEqual(findWeight, foundByWeight.Weight);
        }

        [TestMethod]
        public void TestFindByNameReturnsNullIfNotFound()
        {
            //Arrange
            string findName = "jeff";
            Dog? foundByName;

            
            //act
            foundByName = repo.GetMammalByName(findName) as Dog;

            //assert
            Assert.IsNull(foundByName);
        }

        [TestMethod]
        public void TestFindByWeightReturnsNullIfNotFound()
        {
            //Arrange
            int findWeight = 22;
            Dog? foundByWeight;

            //act
            foundByWeight = repo.GetMammalByWeight(findWeight) as Dog;

            //assert
            Assert.IsNull(foundByWeight);
        }
    }
}