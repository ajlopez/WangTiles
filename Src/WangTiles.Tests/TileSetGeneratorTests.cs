namespace WangTiles.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TileSetGeneratorTests
    {
        [TestMethod]
        public void GenerateThreeTileSet()
        {
            var gen = new TileSetGenerator();

            var result = gen.Generate(3);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Tiles.Count());
            Assert.IsTrue(result.IsValid());
            Assert.IsTrue(result.HasConsecutiveColors());
        }

        [TestMethod]
        public void GenerateTenThreeTileSet()
        {
            var gen = new TileSetGenerator();

            for (int k = 0; k < 10; k++)
            {
                var result = gen.Generate(3);

                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.Tiles.Count());
                Assert.IsTrue(result.IsValid());
                Assert.IsTrue(result.HasConsecutiveColors());
            }
        }

        [TestMethod]
        public void GenerateTenFiveTileSet()
        {
            var gen = new TileSetGenerator();

            for (int k = 0; k < 10; k++)
            {
                var result = gen.Generate(5);

                Assert.IsNotNull(result);
                Assert.AreEqual(5, result.Tiles.Count());
                Assert.IsTrue(result.IsValid());
                Assert.IsTrue(result.HasConsecutiveColors());
            }
        }
    }
}
