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
            foreach (var tile in this.tiles)
                if (!this.tiles.Any(t => tile.TryEast(t)) ||
                    !this.tiles.Any(t => tile.TryNorth(t)) ||
                    !this.tiles.Any(t => tile.TryWest(t)) ||
                    !this.tiles.Any(t => tile.TrySouth(t)))
                    return false;

            return true;
        }
    }
}

