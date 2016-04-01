namespace WangTiles.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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

        [TestMethod]
        public void IsValid()
        {
            Tile tile1 = new Tile(0, 0, 0, 0);
            Tile tile2 = new Tile(0, 1, 0, 1);
            Tile tile3 = new Tile(0, 0, 0, 1);

            TileSet set0 = new TileSet(new Tile[] { tile1 });
            TileSet set1 = new TileSet(new Tile[] { tile1, tile2 });
            TileSet set2 = new TileSet(new Tile[] { tile1, tile3 });
            TileSet set3 = new TileSet(new Tile[] { tile2, tile3 });

            Assert.IsTrue(set0.IsValid());
            Assert.IsTrue(set1.IsValid());
            Assert.IsFalse(set2.IsValid());
            Assert.IsFalse(set3.IsValid());
        }
    }
}
