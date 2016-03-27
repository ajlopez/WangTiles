namespace WangTiles.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TileTests
    {
        [TestMethod]
        public void CreateTileWithColors()
        {
            var tile = new Tile(0, 1, 2, 3);

            Assert.AreEqual(0, tile.East);
            Assert.AreEqual(1, tile.North);
            Assert.AreEqual(2, tile.West);
            Assert.AreEqual(3, tile.South);
        }

        [TestMethod]
        public void Equals()
        {
            var tile1 = new Tile(0, 1, 2, 3);
            var tile2 = new Tile(0, 1, 2, 2);
            var tile3 = new Tile(0, 1, 2, 3);

            Assert.IsTrue(tile1.Equals(tile1));
            Assert.IsTrue(tile1.Equals(tile3));
            Assert.IsFalse(tile1.Equals(tile2));

            Assert.AreEqual(tile1.GetHashCode(), tile3.GetHashCode());
        }

        [TestMethod]
        public void TryEast()
        {
            var tile1 = new Tile(0, 1, 2, 3);
            var tile2 = new Tile(0, 1, 0, 2);
            var tile3 = new Tile(0, 1, 2, 3);

            Assert.IsTrue(tile1.TryEast(tile2));
            Assert.IsFalse(tile1.TryEast(tile3));
        }

        [TestMethod]
        public void TryNorth()
        {
            var tile1 = new Tile(0, 1, 2, 3);
            var tile2 = new Tile(0, 1, 0, 1);
            var tile3 = new Tile(0, 1, 2, 3);

            Assert.IsTrue(tile1.TryNorth(tile2));
            Assert.IsFalse(tile1.TryNorth(tile3));
        }
    }
}
