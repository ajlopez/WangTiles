namespace WangTiles.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MultiTileTests
    {
        [TestMethod]
        public void CreateMultiTileFromTile()
        {
            var mtile = new MultiTile(new Tile[] { new Tile(0, 1, 2, 3) });

            Assert.AreEqual(0x01, mtile.East);
            Assert.AreEqual(0x02, mtile.North);
            Assert.AreEqual(0x04, mtile.West);
            Assert.AreEqual(0x08, mtile.South);
        }

        [TestMethod]
        public void CreateMultiTileFromColors()
        {
            var mtile = new MultiTile(new short[] { 1, 2, 4, 8 });

            Assert.AreEqual(0x01, mtile.East);
            Assert.AreEqual(0x02, mtile.North);
            Assert.AreEqual(0x04, mtile.West);
            Assert.AreEqual(0x08, mtile.South);
        }

        [TestMethod]
        public void CreateMultiTileFromRepeatedTiles()
        {
            Tile tile = new Tile(0, 1, 2, 3);
            var mtile = new MultiTile(new Tile[] { tile, tile });

            Assert.AreEqual(0x01, mtile.East);
            Assert.AreEqual(0x02, mtile.North);
            Assert.AreEqual(0x04, mtile.West);
            Assert.AreEqual(0x08, mtile.South);
        }

        [TestMethod]
        public void CreateMultiTileFromTwoTiles()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);

            var mtile = new MultiTile(new Tile[] { tile1, tile2 });

            Assert.AreEqual(0x03, mtile.East);
            Assert.AreEqual(0x06, mtile.North);
            Assert.AreEqual(0x0c, mtile.West);
            Assert.AreEqual(0x18, mtile.South);
        }
    }
}
