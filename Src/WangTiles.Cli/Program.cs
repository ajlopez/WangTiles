﻿namespace WangTiles.Cli
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            var verb = args[0];

            if (verb == "validate")
            {
                IList<Tile> tiles = new List<Tile>();

                for (int k = 1; k < args.Length; k++)
                    tiles.Add(new Tile(args[k]));

                var tset = new TileSet(tiles);

                if (tset.IsValid())
                    Console.WriteLine("Valid set");
                else
                    Console.WriteLine("Invalid set");
            }
            else if (verb == "random")
            {
                int ntiles = int.Parse(args[1]);
                TileSetGenerator gen = new TileSetGenerator();
                TileSet tset = gen.Generate(ntiles);

                foreach (Tile tile in tset.Tiles)
                    Console.Write(tile.ToString() + " ");

                Console.WriteLine();
            }
            else if (verb == "process")
            {
                int ntiles = int.Parse(args[1]);
                TileSetGenerator gen = new TileSetGenerator();
                TileSet tset = gen.Generate(ntiles);

                foreach (Tile tile in tset.Tiles)
                    Console.Write(tile.ToString() + " ");

                Console.WriteLine();

                MultiTilePlane plane = new MultiTilePlane(tset);

                try
                {
                    Tile tile = null;
                    int nocolors = 0;

                    foreach (var t in tset.Tiles)
                        if (t.NoColors() > nocolors)
                        {
                            tile = t;
                            nocolors = t.NoColors();
                        }

                    plane.Process(0, 0, tile);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                int size = plane.Size;
                int ncolors = tset.MaxColor() + 1;
                MultiTile defmtile = new MultiTile(tset.Tiles);

                for (int y = size; y >= -size; y--)
                {
                    int nt = 0;

                    for (int x = -size; x <= size; x++)
                    {
                        var mtile = plane.Get(x, y);

                        if (!mtile.Equals(defmtile))
                        {
                            if (nt == 0)
                                Console.Write("({0},{1}): ", y, x);
                            Console.Write(mtile.ToString(ncolors) + " ");
                            nt++;
                        }
                    }

                    if (nt > 0)
                        Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Invalid verb {0}", verb);
        }
    }
}

