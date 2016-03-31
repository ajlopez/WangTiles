namespace WangTiles.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TileSetTests
    {
        [TestMethod]
        public void CreateWithTiles()
        {
            Tile tile1 = new Tile(0, 0, 0, 0);
            Tile tile2 = new Tile(0, 1, 0, 1);

            TileSet set = new TileSet(new Tile[] { tile1, tile2 });

            Assert.IsNotNull(set.Tiles);
            Assert.AreEqual(2, set.Tiles.Count());
            Assert.IsTrue(set.Tiles.Contains(tile1));
            Assert.IsTrue(set.Tiles.Contains(tile2));
        }
    }
}
