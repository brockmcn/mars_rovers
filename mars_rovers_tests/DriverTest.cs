using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRovers;

namespace MarsRoversTests
{
    /// <summary>
    /// Tests outputs based on inputs
    /// </summary>
    [TestClass]
    public class DriverTest
    {
        /// <summary>
        /// Test file inputs
        /// </summary>
        [TestMethod]
        public void TestFileInput()
        {
            // 1 rover
            string[] args1 = { "InputTest1Rover.txt", "OutputTest1Rover.txt" };
            Driver.Main(args1);

            // 2 rover
            string[] args2 = { "InputTest2Rover.txt", "OutputTest2Rover.txt" };
            Driver.Main(args2);

            // No output file given
            string[] args3 = { "InputTest2Rover.txt" };
            Driver.Main(args3);

            // Bad input file
            string[] args4 = { "InputBad.txt", "SomeOutput.txt" };
            Driver.Main(args4);

            // Input file does not exist
            string[] args5 = { "NoFile.txt" };
            Driver.Main(args5);
        }

        /// <summary>
        /// Test args inputs
        /// </summary>
        public void TestArgsInput()
        {
            // 1 rover
            string[] args1 = { "11", "11", "3", "4", "E", "RMLRMML" };
            Driver.Main(args1);

            // 2 rover
            string[] args2 = { "5", "5", "1", "2", "N", "LMLMLMLMM", "3", "3", "E", "MMRMMRMRRM" };
            Driver.Main(args2);

            // Bad input
            string[] args3 = { "a1", "11", "3", "4", "E", "RMLRMML" };
            Driver.Main(args3);

            // Invalid rover position
            string[] args4 = { "11", "11", "12", "4", "E", "RMLRMML" };
            Driver.Main(args4);

            // Invalid rover heading
            string[] args5 = { "11", "11", "3", "4", "T", "RMLRMML" };
            Driver.Main(args5);

            // No instructions
            string[] args6 = { "5", "5", "1", "2", "N" };
            Driver.Main(args6);

            // No input
            string[] args7 = {};
            Driver.Main(args7);
        }
    }
}
