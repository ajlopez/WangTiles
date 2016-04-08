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
        private MultiTile mtdefault;

        public MultiTilePlane()
        {
            this.size = 5;
            this.plane = new MultiTile[11, 11];
        }

        public MultiTilePlane(TileSet tset)
            : this()
        {
            this.mtdefault = new MultiTile(tset);
        }

        public MultiTile Get(int x, int y)
        {
            var result = this.plane[x + this.size, y + this.size];

            if (result == null && this.mtdefault != null)
                result = this.plane[x + this.size, y + this.size] = this.mtdefault.Clone();

            return result;
        }

        public void Set(int x, int y, MultiTile mtile)
        {
            this.plane[x + this.size, y + this.size] = mtile;
        }
    }
}
