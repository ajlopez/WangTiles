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
        }
    }
}
