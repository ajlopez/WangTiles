namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MultiTile
    {
        private short[] colors;

        public MultiTile(IEnumerable<Tile> tiles)
        {
            this.colors = new short[4];

            foreach (var tile in tiles)
            {
                this.colors[0] |= ColorToBit(tile.East);
                this.colors[1] |= ColorToBit(tile.North);
                this.colors[2] |= ColorToBit(tile.West);
                this.colors[3] |= ColorToBit(tile.South);
            }
        }

        public MultiTile(TileSet tset)
            : this(tset.Tiles)
        {
        }

        public MultiTile(short[] colors)
        {
            this.colors = colors;
        }

        public short East { get { return this.colors[0]; } }

        public short North { get { return this.colors[1]; } }

        public short West { get { return this.colors[2]; } }

        public short South { get { return this.colors[3]; } }

        public MultiTile Combine(MultiTile tile)
        {
            short[] colors = new short[4];

            for (int k = 0; k < 4; k++)
                colors[k] = (short)(this.colors[k] | tile.colors[k]);

            return new MultiTile(colors);
        }

        public MultiTile Clone()
        {
            short[] colors = new short[4];

            Array.Copy(this.colors, colors, 4);

            return new MultiTile(colors);
        }

        public short GetDirection(Direction direction)
        {
            return this.colors[(int)direction];
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;

            if (!(obj is MultiTile))
                return false;

            MultiTile tile = (MultiTile)obj;

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

        private static short ColorToBit(byte color)
        {
            return (short)(1 << color);
        }
    }
}
