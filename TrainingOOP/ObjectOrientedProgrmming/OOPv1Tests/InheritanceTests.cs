using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IncorrectOOPv1.Tests
{
    [TestClass()]
    public class InheritanceTests
    {
        //private Mock<HomeFurniture> _moq1;
        //private Mock<SleepFurniture> _moq2;
        //private Mock<SofaBed> _moq3;
        //private Mock<Sofa> _moq4;
        //private Mock<Bed> _moq5;

        Furniture f;
        HomeFurniture f1;
        SleepFurniture f2;
        SofaBed f3;
        Sofa f4;
        Bed f5;

        [TestInitialize()]
        public void Initialising()
        {
            //_moq1 = new Mock<HomeFurniture>();
            //_moq2 = new Mock<SleepFurniture>();
            //_moq3 = new Mock<SofaBed>();
            //_moq4 = new Mock<Sofa>();
            //_moq5 = new Mock<Bed>();

            f = new Furniture("Sofa", "Wood");
            f1 = new HomeFurniture("Chair", "Metal", "Red");
            f2 = new SleepFurniture("Chair", "Metal", "Red");
            f3 = new SofaBed("Sofa", "Wood", "Red");
            f4 = new Sofa("Chair", "Plastic", "Red");
            f5 = new Bed("Chair", "Metal", "Red");

        }

        [TestMethod()]
        public void BreakTheFurnitureFurnitureTest()
        {
            Furniture ff = new Furniture(f.Name, f.Material, f.Age);
            f.BreakTheFurniture();
            Assert.AreNotEqual(ff, f);
        }

        [TestMethod()]
        public void IsComfortableHomeFurnitureTest()
        {
            Assert.IsFalse(f1.IsComfortable());
            Assert.IsTrue(new HomeFurniture(f.Name, f.Material, "Black").IsComfortable());
        }

        [TestMethod()]
        public void IsComfortableSleepFurnitureTest()
        {
            Assert.IsFalse(f2.IsComfortable());
            //Assert.IsTrue();
        }

        [TestMethod()]
        public void BreakTheFurnitureSofaBedTest()
        {
            SofaBed ff = new SofaBed(f3.Name, f3.Material, f3.Color);
            f3.BreakTheFurniture();

            Assert.AreNotEqual(f3,ff);
        }

        [TestMethod()]
        public void IsComfortableSofaTest()
        {
            Assert.IsFalse(f4.IsComfortable());

        }

        [TestMethod()]
        public void BreakTheFurnitureSofaTest()
        {

            Sofa ff = new Sofa(f4.Name, f4.Material, f4.Color);
            f4.BreakTheFurniture();

            Assert.AreNotEqual(f4, ff);
        }

        [TestMethod()]
        public void IsComfortableBedTest()
        {
            Assert.IsFalse(f5.IsComfortable());
        }

        [TestMethod()]
        public void BreakTheFurnitureBedTest()
        {
            Sofa ff = new Sofa(f5.Name, f5.Material, f5.Color);
            f5.BreakTheFurniture();

            Assert.AreNotEqual(f5, ff);
        }
    }
}