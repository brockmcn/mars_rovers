using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRovers;

namespace MarsRoversTests
{
    /// <summary>
    /// Test rover functions
    /// </summary>
    [TestClass]
    public class RoverTest
    {
        /// <summary>
        /// Test rover left rotates
        /// </summary>
        [TestMethod]
        public void TestLeftRotate()
        {
            Point origin = new Point(0, 0);
            Rover rover = new Rover(origin, 'N');

            // Rotate left to west
            rover.Rotate('L');
            char expected = 'W';
            char actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Incorrect rotate left to west");

            // Rotate left to south
            rover.Rotate('L');
            expected = 'S';
            actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Incorrect rotate left to south");


            // Rotate left to east
            rover.Rotate('L');
            expected = 'E';
            actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Incorrect rotate left to east");

            // Rotate left to north
            rover.Rotate('L');
            expected = 'N';
            actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Incorrect rotate leftto north");
        }

        /// <summary>
        /// Test rover right rotates
        /// </summary>
        [TestMethod]
        public void TestRightRotate()
        {
            Point origin = new Point(0, 0);
            Rover rover = new Rover(origin, 'N');

            // Rotate right to east
            rover.Rotate('R');
            char expected = 'E';
            char actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Incorrect rotate right to east");

            // Rotate right to south
            rover.Rotate('R');
            expected = 'S';
            actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Incorrect rotate right to south");

            // Rotate right to west
            rover.Rotate('R');
            expected = 'W';
            actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Incorrect rotate right to west");

            // Rotate right to north
            rover.Rotate('R');
            expected = 'N';
            actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Incorrect rotate right to north");
        }

        /// <summary>
        /// Test a rotate with a invalid instruction
        /// </summary>
        [TestMethod]
        public void TestUndefinedRotate()
        {
            Point origin = new Point(0, 0);
            Rover rover = new Rover(origin, 'N');

            rover.Rotate('T');
            char expected = 'N';
            char actual = rover.Heading;

            Assert.AreEqual(expected, actual, "Undefined rotate handled incorrectly");
        }

        /// <summary>
        /// Test rover movement
        /// </summary>
        [TestMethod]
        public void TestMove()
        {
            Grid grid = new Grid(5, 5);
            Point origin = new Point(0, 0);
            Rover rover = new Rover(origin, 'E');

            // Test moving east
            rover.Move(grid);
            string expected = new Point(1, 0).ToString();
            string actual = rover.Position.ToString();

            Assert.AreEqual(expected, actual, "Incorrect east move");

            // Test moving north
            rover.Rotate('L');
            rover.Move(grid);
            expected = new Point(1, 1).ToString();
            actual = rover.Position.ToString();

            Assert.AreEqual(expected, actual, "Incorrect north move");

            // Test moving west
            rover.Rotate('L');
            rover.Move(grid);
            expected = new Point(0, 1).ToString();
            actual = rover.Position.ToString();

            Assert.AreEqual(expected, actual, "Incorrect west move");

            // Test moving south
            rover.Rotate('L');
            rover.Move(grid);
            expected = new Point(0, 0).ToString();
            actual = rover.Position.ToString();

            Assert.AreEqual(expected, actual, "Incorrect south move");

            // Test moving west out of bounds
            rover = new Rover(new Point(0, 0), 'W');
            rover.Move(grid);
            expected = new Point(0, 0).ToString();
            actual = rover.Position.ToString();

            Assert.AreEqual(expected, actual, "Incorrect west out of bounds move");

            // Test moving north out of bounds
            rover = new Rover(new Point(5, 5), 'N');
            rover.Move(grid);
            expected = new Point(5, 5).ToString();
            actual = rover.Position.ToString();

            Assert.AreEqual(expected, actual, "Incorrect north out of bounds move");

            // Test moving east out of bounds
            rover = new Rover(new Point(5, 5), 'E');
            rover.Move(grid);
            expected = new Point(5, 5).ToString();
            actual = rover.Position.ToString();

            Assert.AreEqual(expected, actual, "Incorrect east out of bounds move");

            // Test moving south out of bounds
            rover = new Rover(new Point(0, 0), 'S');
            rover.Move(grid);
            expected = new Point(0, 0).ToString();
            actual = rover.Position.ToString();

            Assert.AreEqual(expected, actual, "Incorrect south out of bounds move");
        }
    }
}
