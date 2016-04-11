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
            : this(10)
        {
        }

        public MultiTilePlane(int size)
        {
            this.size = size;
            this.plane = new MultiTile[(size * 2) + 1, (size * 2) + 1];
        }

        public MultiTilePlane(TileSet tset)
            : this()
        {
            this.tset = tset;
            this.mtdefault = new MultiTile(tset);
        }

        public int Size { get { return this.size; } }

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

        public IEnumerable<MultiTileAction> SetActions(int x, int y, MultiTile mtile)
        {
            IList<MultiTileAction> actions = new List<MultiTileAction>();

            actions.Add(new MultiTileAction(mtile.East, Direction.East, x, y));
            actions.Add(new MultiTileAction(mtile.North, Direction.North, x, y));
            actions.Add(new MultiTileAction(mtile.West, Direction.West, x, y));
            actions.Add(new MultiTileAction(mtile.South, Direction.South, x, y));

            return actions;
        }

        public void Process(int x, int y, Tile tile)
        {
            MultiTile mtile = new MultiTile(new Tile[] { tile });
            var actions = this.SetActions(x, y, mtile);
            var queue = new MultiTileActionQueue();

            queue.Enqueue(actions);

            for (var action = queue.Dequeue(); action != null; action = queue.Dequeue())
                queue.Enqueue(this.Apply(action));
        }

        public IEnumerable<MultiTileAction> Apply(MultiTileAction action)
        {
            if (action.X < -this.size || action.X > this.size || action.Y < -this.size || action.Y > this.size)
                return null;

            var tile = this.Get(action.X, action.Y);
            ushort original = tile.GetDirection(action.Direction);
            ushort newvalue = (ushort)(original & action.Value);

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

            var newmtile = new MultiTile(this.tset.SelectByColors(newvalue, action.Direction));

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
