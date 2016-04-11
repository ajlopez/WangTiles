namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MultiTile
    {
        private ushort[] colors;

        public MultiTile(IEnumerable<Tile> tiles)
        {
            this.colors = new ushort[4];

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

        public MultiTile(ushort[] colors)
        {
            this.colors = colors;
        }

        public ushort East { get { return this.colors[0]; } }

        public ushort North { get { return this.colors[1]; } }

        public ushort West { get { return this.colors[2]; } }

        public ushort South { get { return this.colors[3]; } }

        public MultiTile Combine(MultiTile tile)
        {
            ushort[] colors = new ushort[4];

            for (int k = 0; k < 4; k++)
                colors[k] = (ushort)(this.colors[k] | tile.colors[k]);

            return new MultiTile(colors);
        }

        public MultiTile Clone()
        {
            ushort[] colors = new ushort[4];

            Array.Copy(this.colors, colors, 4);

            return new MultiTile(colors);
        }

        public ushort GetDirection(Direction direction)
        {
            return this.colors[(int)direction];
        }

        public void SetDirection(Direction direction, ushort value)
        {
            this.colors[(int)direction] = value;
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

        public override string ToString()
        {
            return ColorsToString(this.colors[0]) + "-" + ColorsToString(this.colors[1]) + "-" + ColorsToString(this.colors[2]) + "-" + ColorsToString(this.colors[3]);
        }

        public string ToString(int width)
        {
            return ColorsToString(this.colors[0], width) + "-" + ColorsToString(this.colors[1], width) + "-" + ColorsToString(this.colors[2], width) + "-" + ColorsToString(this.colors[3], width);
        }

        private static ushort ColorToBit(short color)
        {
            return (ushort)(1 << color);
        }

        private static string ColorsToString(ushort colors, int width = 0)
        {
            string result = string.Empty;

            while (colors != 0)
            {
                if ((colors & 1) != 0)
                    result = "1" + result;
                else
                    result = "0" + result;

                colors >>= 1;
            }

            if (result.Length == 0)
                result = "0";

            if (width > 0)
                while (result.Length < width)
                    result = "0" + result;

            return result;
        }
    }
}
