namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MultiTilePlane
    {
        private int size;
        private MultiTile[,] plane;

        public MultiTilePlane()
        {
            this.size = 5;
            this.plane = new MultiTile[11, 11];
        }

        public MultiTile Get(int x, int y)
        {
            return this.plane[x + this.size, y + this.size];
        }

        public void Set(int x, int y, MultiTile mtile)
        {
            this.plane[x + this.size, y + this.size] = mtile;
        }
    }
}
