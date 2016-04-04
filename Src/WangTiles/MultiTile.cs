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

        public MultiTile(short[] colors)
        {
            this.colors = colors;
        }

        public short East { get { return this.colors[0]; } }

        public short North { get { return this.colors[1]; } }

        public short West { get { return this.colors[2]; } }

        public short South { get { return this.colors[3]; } }

        private short ColorToBit(byte color)
        {
            return (short)(1 << color);
        }
    }
}
