namespace WangTiles.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MultiTileActionTests
    {
        [TestMethod]
        public void CreateAction()
        {
            MultiTileAction action = new MultiTileAction(1, Direction.East, 2, 3);

            Assert.AreEqual(1, action.Value);
            Assert.AreEqual(Direction.East, action.Direction);
            Assert.AreEqual(2, action.X);
            Assert.AreEqual(3, action.Y);
        }
    }
}
