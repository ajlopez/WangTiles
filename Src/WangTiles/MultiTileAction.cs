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

        public MultiTileAction Move(int dx, int dy)
        {
            return new MultiTileAction(this.value, this.direction, this.x + dx, this.y + dy);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is MultiTileAction))
                return false;

            MultiTileAction action = (MultiTileAction)obj;

            if (this.value != action.value)
                return false;

            if (this.direction != action.direction)
                return false;

            if (this.x != action.x)
                return false;

            if (this.y != action.y)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            int value = 0;

            value += this.value;
            value *= 17;
            value += (int)this.direction;
            value *= 17;
            value += this.x;
            value *= 17;
            value += this.y;

            return value;
        }
    }
}

