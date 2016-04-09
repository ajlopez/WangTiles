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

        [TestMethod]
        public void MoveAction()
        {
            MultiTileAction action = new MultiTileAction(1, Direction.East, 2, 3);

            var result = action.Move(-1, 2);

            Assert.AreNotSame(action, result);
            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(Direction.East, result.Direction);
            Assert.AreEqual(1, result.X);
            Assert.AreEqual(5, result.Y);
        }
    }
}
