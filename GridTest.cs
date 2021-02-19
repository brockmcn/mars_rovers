using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRovers;

namespace MarsRoversTests
{
    /// <summary>
    /// Grid object test
    /// </summary>
    [TestClass]
    public class GridTest
    {
        /// <summary>
        /// Test Grid width
        /// </summary>
        [TestMethod]
        public void TestWidth()
        {
            Grid grid = new Grid(5, 5);

            int expected = 5;
            int actual = grid.Width;
            Assert.AreEqual(expected, actual, "Incorrect width");
        }

        /// <summary>
        /// Test Grid height
        /// </summary>
        [TestMethod]
        public void TestHeight()
        {
            Grid grid = new Grid(3, 2);

            int expected = 2;
            int actual = grid.Height;
            Assert.AreEqual(expected, actual, "Incorrect height");
        }
    }
}
