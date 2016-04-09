namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MultiTileAction
    {
        private short value;
        private int x;
        private int y;
        private Direction direction;

        public MultiTileAction(short value, Direction direction, int x, int y)
        {
            this.value = value;
            this.direction = direction;
            this.x = x;
            this.y = y;
        }

        public short Value { get { return this.value; } }

        public Direction Direction { get { return this.direction; } }

        public int X { get { return this.x; } }

        public int Y { get { return this.y; } }
    }
}

