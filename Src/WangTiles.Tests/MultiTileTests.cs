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
    }
}
