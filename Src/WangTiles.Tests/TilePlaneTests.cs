namespace WangTiles.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TilePlaneTests
    {
        [TestMethod]
        public void EmptyAtCreation()
        {
            var plane = new TilePlane();

            Assert.IsTrue(plane.IsEmpty);
            Assert.AreEqual(10, plane.Size);
        }

        [TestMethod]
        public void SizeFive()
        {
            var plane = new TilePlane(5);

            Assert.IsTrue(plane.IsEmpty);
            Assert.AreEqual(5, plane.Size);
        }
    }
}
