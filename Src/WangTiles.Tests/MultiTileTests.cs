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
        public void GetDirection()
        {
            var mtile = new MultiTile(new short[] { 1, 2, 4, 8 });

            Assert.AreEqual(0x01, mtile.GetDirection(Direction.East));
            Assert.AreEqual(0x02, mtile.GetDirection(Direction.North));
            Assert.AreEqual(0x04, mtile.GetDirection(Direction.West));
            Assert.AreEqual(0x08, mtile.GetDirection(Direction.South));
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

        [TestMethod]
        public void CreateMultiTileFromTileSet()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);
            TileSet tset = new TileSet(new Tile[] { tile1, tile2 });

            var mtile = new MultiTile(tset);

            Assert.AreEqual(0x03, mtile.East);
            Assert.AreEqual(0x06, mtile.North);
            Assert.AreEqual(0x0c, mtile.West);
            Assert.AreEqual(0x18, mtile.South);
        }

        [TestMethod]
        public void CombineMultiTiles()
        {
            var mtile1 = new MultiTile(new short[] { 1, 2, 4, 8 });
            var mtile2 = new MultiTile(new short[] { 2, 4, 8, 16 });

            var mtile = mtile1.Combine(mtile2);

            Assert.AreEqual(0x03, mtile.East);
            Assert.AreEqual(0x06, mtile.North);
            Assert.AreEqual(0x0c, mtile.West);
            Assert.AreEqual(0x18, mtile.South);
        }

        [TestMethod]
        public void CloneMultiTile()
        {
            var mtile = new MultiTile(new short[] { 1, 2, 4, 8 });

            var result = mtile.Clone();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.East);
            Assert.AreEqual(2, result.North);
            Assert.AreEqual(4, result.West);
            Assert.AreEqual(8, result.South);

            Assert.AreNotSame(mtile, result);
        }

        [TestMethod]
        public void Equals()
        {
            var mtile1 = new MultiTile(new short[] { 1, 2, 4, 8 });
            var mtile2 = new MultiTile(new short[] { 1, 2, 2, 1 });
            var mtile3 = new MultiTile(new short[] { 1, 2, 4, 8 });

            Assert.IsTrue(mtile1.Equals(mtile3));
            Assert.IsFalse(mtile1.Equals(mtile2));
            Assert.IsFalse(mtile2.Equals(mtile1));
            Assert.IsFalse(mtile1.Equals(null));
            Assert.IsFalse(mtile1.Equals("foo"));

            Assert.AreEqual(mtile3.GetHashCode(), mtile1.GetHashCode());
        }
    }
}
