﻿namespace WangTiles.Tests
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
            Assert.AreEqual(10, plane.Size);
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
            var mtile = new MultiTile(new ushort[] { 1, 2, 4, 8 });
            var plane = new MultiTilePlane();

            plane.Set(0, 0, mtile);

            var result = plane.Get(0, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.East);
            Assert.AreEqual(2, result.North);
            Assert.AreEqual(4, result.West);
            Assert.AreEqual(8, result.South);
        }

        [TestMethod]
        public void ApplyActionWithoutChanges()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);
            TileSet tset = new TileSet(new Tile[] { tile1, tile2 });
            MultiTile mtile = new MultiTile(tset);

            var plane = new MultiTilePlane(tset);

            var result = plane.Apply(new MultiTileAction(mtile.East, Direction.East, 0, 0));
            Assert.IsNull(result);

            result = plane.Apply(new MultiTileAction(mtile.North, Direction.North, 0, 0));
            Assert.IsNull(result);

            result = plane.Apply(new MultiTileAction(mtile.West, Direction.West, 0, 0));
            Assert.IsNull(result);

            result = plane.Apply(new MultiTileAction(mtile.South, Direction.South, 0, 0));
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ApplyActionToEast()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);
            TileSet tset = new TileSet(new Tile[] { tile1, tile2 });

            var plane = new MultiTilePlane(tset);

            var result = plane.Apply(new MultiTileAction(1, Direction.East, 0, 0));
            
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.IsTrue(result.Contains(new MultiTileAction(1, Direction.West, 1, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(2, Direction.North, 0, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(4, Direction.West, 0, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(8, Direction.South, 0, 0)));
        }

        [TestMethod]
        public void ApplyActionToNorth()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);
            TileSet tset = new TileSet(new Tile[] { tile1, tile2 });

            var plane = new MultiTilePlane(tset);

            var result = plane.Apply(new MultiTileAction(2, Direction.North, 0, 0));

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.IsTrue(result.Contains(new MultiTileAction(2, Direction.South, 0, 1)));
            Assert.IsTrue(result.Contains(new MultiTileAction(1, Direction.East, 0, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(4, Direction.West, 0, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(8, Direction.South, 0, 0)));
        }

        [TestMethod]
        public void ApplyActionToWest()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);
            TileSet tset = new TileSet(new Tile[] { tile1, tile2 });

            var plane = new MultiTilePlane(tset);

            var result = plane.Apply(new MultiTileAction(4, Direction.West, 0, 0));

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.IsTrue(result.Contains(new MultiTileAction(4, Direction.East, -1, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(1, Direction.East, 0, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(2, Direction.North, 0, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(8, Direction.South, 0, 0)));
        }

        [TestMethod]
        public void ApplyActionTooFar()
        {
            var plane = new MultiTilePlane();

            Assert.IsNull(plane.Apply(new MultiTileAction(4, Direction.West, -100, 0)));
            Assert.IsNull(plane.Apply(new MultiTileAction(4, Direction.West, 100, 0)));
            Assert.IsNull(plane.Apply(new MultiTileAction(4, Direction.West, 0, -100)));
            Assert.IsNull(plane.Apply(new MultiTileAction(4, Direction.West, 0, 100)));
        }

        [TestMethod]
        public void ApplyActionToSouth()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);
            TileSet tset = new TileSet(new Tile[] { tile1, tile2 });

            var plane = new MultiTilePlane(tset);

            var result = plane.Apply(new MultiTileAction(8, Direction.South, 0, 0));

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.IsTrue(result.Contains(new MultiTileAction(8, Direction.North, 0, -1)));
            Assert.IsTrue(result.Contains(new MultiTileAction(1, Direction.East, 0, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(2, Direction.North, 0, 0)));
            Assert.IsTrue(result.Contains(new MultiTileAction(4, Direction.West, 0, 0)));
        }

        [TestMethod]
        public void ApplyInvalidActionToEast()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(1, 2, 3, 4);
            TileSet tset = new TileSet(new Tile[] { tile1, tile2 });

            var plane = new MultiTilePlane(tset);

            try
            {
                plane.Apply(new MultiTileAction(4, Direction.East, 0, 0));
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Contradiction", ex.Message);
            }
        }

        [TestMethod]
        public void ProcessTileRaisingContradiction()
        {
            Tile tile1 = new Tile(0, 1, 2, 3);
            Tile tile2 = new Tile(2, 3, 3, 1);
            Tile tile3 = new Tile(3, 3, 0, 1);

            TileSet tset = new TileSet(new Tile[] { tile1, tile2, tile3 });

            Assert.IsTrue(tset.IsValid());

            var plane = new MultiTilePlane(tset);

            try
            {
                plane.Process(0, 0, tile3);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Contradiction", ex.Message);
            }
        }

        [TestMethod]
        public void SetActions()
        {
            var plane = new MultiTilePlane();

            var actions = plane.SetActions(1, 2, new MultiTile(new ushort[] { 1, 2, 4, 8 }));

            Assert.IsNotNull(actions);
            Assert.AreEqual(4, actions.Count());
            Assert.IsTrue(actions.Contains(new MultiTileAction(1, Direction.East, 1, 2)));
            Assert.IsTrue(actions.Contains(new MultiTileAction(2, Direction.North, 1, 2)));
            Assert.IsTrue(actions.Contains(new MultiTileAction(4, Direction.West, 1, 2)));
            Assert.IsTrue(actions.Contains(new MultiTileAction(8, Direction.South, 1, 2)));
        }
    }
}
