namespace WangTiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TileSetGenerator
    {
        private Random random = new Random();

        public TileSet Generate(int ntiles)
        {
            int size = ntiles * 4;
            short[] colors = new short[size];

            for (int k = 0; k < size; k++)
                colors[k] = -1;

            int ncolors = 0;
            int[] others = new int[ntiles];

            for (int k = 0; k < size; k++)
            {
                if (colors[k] >= 0)
                    continue;

                if (ncolors == 0)
                    colors[k] = 0;
                else
                    colors[k] = (short)this.random.Next(Math.Min(ncolors + 1, size * 2));

                if (colors[k] == ncolors)
                    ncolors++;

                int j0 = (k + 2) % 4;
                int nothers = 0;
                bool valid = false;

                for (int j = j0; j < size; j += 4)
                {
                    if (colors[j] == -1)
                        others[nothers++] = j;

                    if (colors[j] == colors[k])
                        valid = true;
                }

                if (valid)
                    continue;

                if (nothers == 0)
                {
                    colors[k] = -1;
                    k--;
                    continue;
                }

                colors[others[this.random.Next(nothers)]] = colors[k];
            }

            Tile[] tiles = new Tile[ntiles];

            for (int k = 0; k < ntiles; k++)
                tiles[k] = new Tile(colors[k * 4], colors[k * 4 + 1], colors[k * 4 + 2], colors[k * 4 + 3]);

            return new TileSet(tiles);
        }
    }
}
