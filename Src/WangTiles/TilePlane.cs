namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TilePlane
    {
        private int size;
        private MultiTile[,] plane;

        public TilePlane()
            : this(10)
        {
        }

        public TilePlane(int size)
        {
            this.size = size;
            this.plane = new MultiTile[(size * 2) + 1, (size * 2) + 1];
        }

        public bool IsEmpty { get { return true; } }

        public int Size { get { return this.size; } }
    }
}
