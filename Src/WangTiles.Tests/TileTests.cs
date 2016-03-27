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
    }
}
