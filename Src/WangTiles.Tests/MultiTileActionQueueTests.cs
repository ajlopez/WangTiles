namespace WangTiles.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MultiTileActionQueueTests
    {
        [TestMethod]
        public void DequeueFromEmptyQueue()
        {
            var queue = new MultiTileActionQueue();

            Assert.IsNull(queue.Dequeue());
        }

        [TestMethod]
        public void EnqueueAndDequeueAction()
        {
            var action = new MultiTileAction(1, Direction.East, 0, 0);
            var queue = new MultiTileActionQueue();

            queue.Enqueue(action);

            var result = queue.Dequeue();

            Assert.IsNotNull(result);
            Assert.AreEqual(action, result);

            Assert.IsNull(queue.Dequeue());
        }

        [TestMethod]
        public void EnqueueAndDequeueTwoActionsSortedByDistance()
        {
            var action1 = new MultiTileAction(1, Direction.East, 1, -1);
            var action2 = new MultiTileAction(1, Direction.East, 0, 1);
            var queue = new MultiTileActionQueue();

            queue.Enqueue(new MultiTileAction[] { action1, action2 });

            var result = queue.Dequeue();

            Assert.IsNotNull(result);
            Assert.AreEqual(action2, result);

            result = queue.Dequeue();

            Assert.IsNotNull(result);
            Assert.AreEqual(action1, result);

            Assert.IsNull(queue.Dequeue());
        }
    }
}
