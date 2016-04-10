namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tile
    {
        private byte[] colors = new byte[4];

        public Tile(short east, short north, short west, short south)
        {
            this.colors[0] = (byte)east;
            this.colors[1] = (byte)north;
            this.colors[2] = (byte)west;
            this.colors[3] = (byte)south;
        }

        public Tile(string text)
        {
            this.colors[0] = (byte)(text[0] - '0');
            this.colors[1] = (byte)(text[1] - '0');
            this.colors[2] = (byte)(text[2] - '0');
            this.colors[3] = (byte)(text[3] - '0');
        }

        public byte East { get { return this.colors[(int)Direction.East]; } }

        public byte North { get { return this.colors[(int)Direction.North]; } }

        public byte West { get { return this.colors[(int)Direction.West]; } }

        public byte South { get { return this.colors[(int)Direction.South]; } }

        public byte MaxColor()
        {
            return this.colors.Max();
        }

        public byte GetColor(Direction direction)
        {
            return this.colors[(int)direction];
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;

            if (!(obj is Tile))
                return false;

            Tile tile = (Tile)obj;

            return this.colors[0] == tile.colors[0] && this.colors[1] == tile.colors[1] && this.colors[2] == tile.colors[2] && this.colors[3] == tile.colors[3];
        }

        public override int GetHashCode()
        {
            int value = 0;

            for (int k = 0; k < 4; k++)
            {
                value *= 17;
                value += this.colors[k];
            }

            return value;
        }

        public bool TryEast(Tile tile)
        {
            return this.colors[0] == tile.colors[2];
        }

        public bool TryNorth(Tile tile)
        {
            return this.colors[1] == tile.colors[3];
        }

        public bool TryWest(Tile tile)
        {
            return this.colors[2] == tile.colors[0];
        }

        public bool TrySouth(Tile tile)
        {
            return this.colors[3] == tile.colors[1];
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}", ColorToChar(this.colors[0]), ColorToChar(this.colors[1]), ColorToChar(this.colors[2]), ColorToChar(this.colors[3]));
        }

        private char ColorToChar(byte color)
        {
            if (color >= 0 && color <= 9)
                return (char)('0' + color);

            return (char)('a' + (color - 10));
        }
    }
}
