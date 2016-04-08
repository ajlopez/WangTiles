namespace WangTiles.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MultiTilePlaneTests
    {
        [TestMethod]
        public void CreateEmptyPlane()
        {
            var plane = new MultiTilePlane();

            Assert.IsNull(plane.Get(0, 0));
        }

        [TestMethod]
        public void CreatePlaneWithTileSet()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);
            TileSet tset = new TileSet(new Tile[] { tile1, tile2 });
            MultiTile mtile = new MultiTile(tset);

            var plane = new MultiTilePlane(tset);

            var result = plane.Get(0, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(mtile, result);
            Assert.AreNotSame(mtile, result);
        }

        [TestMethod]
        public void SetAndGetMultiTile()
        {
            var mtile = new MultiTile(new short[] { 1, 2, 4, 8 });
            var plane = new MultiTilePlane();

            plane.Set(0, 0, mtile);

            var result = plane.Get(0, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.East);
            Assert.AreEqual(2, result.North);
            Assert.AreEqual(4, result.West);
            Assert.AreEqual(8, result.South);
        }
    }
}
