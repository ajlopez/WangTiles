namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MultiTileActionQueue
    {
        private int size;
        private Queue<MultiTileAction>[] queues;

        public MultiTileActionQueue()
            : this(18)
        {
        }

        public MultiTileActionQueue(int size)
        {
            this.size = size;
            this.queues = new Queue<MultiTileAction>[size + 1];

            for (int k = 0; k <= size; k++)
                this.queues[k] = new Queue<MultiTileAction>();
        }

        public void Enqueue(MultiTileAction action)
        {
            int distance = Math.Abs(action.X) + Math.Abs(action.Y);

            if (distance < queues.Length)
                queues[distance].Enqueue(action);
        }

        public void Enqueue(IEnumerable<MultiTileAction> actions)
        {
            if (actions == null)
                return;

            foreach (var action in actions)
                this.Enqueue(action);
        }

        public MultiTileAction Dequeue()
        {
            for (int k = 0; k <= this.size; k++)
                if (this.queues[k].Count != 0)
                    return this.queues[k].Dequeue();

            return null;
        }
    }
}

