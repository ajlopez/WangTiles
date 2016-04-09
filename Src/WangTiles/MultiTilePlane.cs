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
        private TileSet tset;
        private MultiTile mtdefault;

        public MultiTilePlane()
        {
            this.size = 5;
            this.plane = new MultiTile[11, 11];
        }

        public MultiTilePlane(TileSet tset)
            : this()
        {
            this.tset = tset;
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

        public IEnumerable<MultiTileAction> Apply(MultiTileAction action)
        {
            var tile = this.Get(action.X, action.Y);
            short original = tile.GetDirection(action.Direction);
            short newvalue = (short)(original & action.Value);

            if (newvalue == original)
                return null;

            if (newvalue == 0)
                throw new InvalidOperationException("Contradiction");

            IList<MultiTileAction> actions = new List<MultiTileAction>();

            switch (action.Direction)
            {
                case Direction.South:
                    actions.Add(new MultiTileAction(newvalue, Direction.North, action.X, action.Y - 1));
                    break;
                case Direction.North:
                    actions.Add(new MultiTileAction(newvalue, Direction.South, action.X, action.Y + 1));
                    break;
                case Direction.East:
                    actions.Add(new MultiTileAction(newvalue, Direction.West, action.X + 1, action.Y));
                    break;
                case Direction.West:
                    actions.Add(new MultiTileAction(newvalue, Direction.East, action.X - 1, action.Y));
                    break;
            }

            tile.SetDirection(action.Direction, newvalue);

            var newmtile = new MultiTile(tset.SelectByColors(newvalue, action.Direction));

            if (action.Direction != Direction.East)
                actions.Add(new MultiTileAction(newmtile.East, Direction.East, action.X, action.Y));
            if (action.Direction != Direction.North)
                actions.Add(new MultiTileAction(newmtile.North, Direction.North, action.X, action.Y));
            if (action.Direction != Direction.West)
                actions.Add(new MultiTileAction(newmtile.West, Direction.West, action.X, action.Y));
            if (action.Direction != Direction.South)
                actions.Add(new MultiTileAction(newmtile.South, Direction.South, action.X, action.Y));

            return actions;
        }
    }
}
