using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangTiles.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var verb = args[0];

            IList<Tile> tiles = new List<Tile>();

            for (int k = 1; k < args.Length; k++)
                tiles.Add(ConvertToTile(args[k]));

            var tset = new TileSet(tiles);

            if (tset.IsValid())
                Console.WriteLine("Valid set");
            else
                Console.WriteLine("Invalid set");
        }

        private static Tile ConvertToTile(string text)
        {
            return new Tile(ConvertToColor(text[0]), ConvertToColor(text[1]), ConvertToColor(text[2]), ConvertToColor(text[3]));
        }

        private static short ConvertToColor(char ch)
        {
            return (short)(ch - '0');
        }
    }
}

