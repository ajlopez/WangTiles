namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TileSet
    {
        private IList<Tile> tiles;

        public TileSet(IEnumerable<Tile> tiles)
        {
            this.tiles = new List<Tile>(tiles);
        }

        public IEnumerable<Tile> Tiles { get { return this.tiles; } }

        public bool IsValid()
        {
            var mtile = new MultiTile(this.tiles);

            return mtile.East == mtile.West && mtile.North == mtile.South;
        }

        public byte MaxColor()
        {
            return this.tiles.Max(t => t.MaxColor());
        }

        public bool HasRepeatedTiles()
        {
            return this.tiles.Select(t => this.tiles.Count(t2 => t2.Equals(t))).Max() > 1;
        }

        public bool HasConsecutiveColors()
        {
            var mtile = new MultiTile(this.tiles);

            ushort colors = (ushort)(mtile.East | mtile.West | mtile.North | mtile.South);

            int ncolors = this.NoColors();

            return colors + 1 == 1 << ncolors;
        }

        public int NoColors()
        {
            var mtile = new MultiTile(this.tiles);

            ushort colors = (ushort)(mtile.East | mtile.West | mtile.North | mtile.South);

            int ncolors = 0;

            while (colors != 0)
            {
                if ((colors & 1) != 0)
                    ncolors++;

                colors >>= 1;
            }

            return ncolors;
        }

        public IList<Tile> SelectByColor(short color, Direction direction)
        {
            var selected = new List<Tile>();

            foreach (var tile in this.tiles)
                if (tile.GetColor(direction) == color)
                    selected.Add(tile);

            return selected;
        }

        public IList<Tile> SelectByColors(ushort colors, Direction direction)
        {
            var selected = new List<Tile>();

            foreach (var tile in this.tiles)
                if (((1 << tile.GetColor(direction)) & colors) != 0)
                    selected.Add(tile);

            return selected;
        }
    }
}

