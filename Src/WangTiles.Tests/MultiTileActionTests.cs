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

        [TestMethod]
        public void Equals()
        {
            MultiTileAction action1 = new MultiTileAction(1, Direction.East, 2, 3);
            MultiTileAction action2 = new MultiTileAction(1, Direction.East, 2, 3);
            MultiTileAction action3 = new MultiTileAction(2, Direction.East, 2, 3);
            MultiTileAction action4 = new MultiTileAction(1, Direction.West, 2, 3);
            MultiTileAction action5 = new MultiTileAction(1, Direction.East, 3, 3);
            MultiTileAction action6 = new MultiTileAction(1, Direction.East, 2, 4);

            Assert.IsTrue(action1.Equals(action2));
            Assert.IsFalse(action1.Equals(action3));
            Assert.IsFalse(action1.Equals(action4));
            Assert.IsFalse(action1.Equals(action5));
            Assert.IsFalse(action1.Equals(action6));
            Assert.IsFalse(action1.Equals(null));
            Assert.IsFalse(action1.Equals("foo"));

            Assert.AreEqual(action1.GetHashCode(), action2.GetHashCode());
        }
    }
}
