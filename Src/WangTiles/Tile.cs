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
    }
}
