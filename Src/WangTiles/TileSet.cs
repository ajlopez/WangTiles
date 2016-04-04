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
    }
}

