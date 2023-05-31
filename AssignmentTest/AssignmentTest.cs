using Assignment;

namespace AssignmentTest
{
    [TestClass]
    public class PackTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(pack.GetMaxCount(), PackMaxItems);
        }

        [TestMethod]
        public void ConstructorNegativeMaxCountTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(-10, 20, 20));
        }

        [TestMethod]
        public void ConstructorNegativeMaxVoloumeTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(10, -20, 20));
        }

        [TestMethod]
        public void ConstructorNegativeMaxWightTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(10, 20, -20));
        }

        [TestMethod]
        public void AddSignleItemTestToAnEmptyPack()
        {
            Pack pack = new(10, 20, 30);
            bool result = pack.Add(new Arrow());
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void OverMaxCountTest()
        {
            Pack pack = new(1, 20, 30);
            pack.Add(new Arrow());
            Assert.AreEqual(false, pack.Add(new Arrow()));
        }

        [TestMethod]
        public void OverMaxWeightTest()
        {
            Pack pack = new(10, 20, 2);
            Assert.AreEqual(false, pack.Add(new Sword()));
        }

        [TestMethod]
        public void OverMaxVolumeTest()
        {
            Pack pack = new(10, 2, 30);
            Assert.AreEqual(false, pack.Add(new Sword()));
        }

        [TestMethod]
        public void AddItemWithNegativeWeight()
        {
            Pack pack = new(10, 2, 30);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Arrow(10, -20)));
        }

        [TestMethod]
        public void AddItemWithNegativeVolume()
        {
            Pack pack = new(10, 2, 30);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Arrow(-10, 20)));
        }

        [TestMethod]
        public void AddItemWithZeroWeight()
        {
            Pack pack = new(10, 2, 30);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Arrow(10, 0)));
        }

        [TestMethod]
        public void AddItemWithZeroVolume()
        {
            Pack pack = new(10, 2, 30);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Arrow(0, 20)));
        }
    }
}
