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
            colors[0] = (byte)east;
            colors[1] = (byte)north;
            colors[2] = (byte)west;
            colors[3] = (byte)south;
        }

        public byte East { get { return this.colors[0]; } }

        public byte North { get { return this.colors[1]; } }

        public byte West { get { return this.colors[2]; } }

        public byte South { get { return this.colors[3]; } }

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
    }
}
