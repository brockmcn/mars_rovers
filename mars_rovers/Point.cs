namespace MarsRovers
{
    /// <summary>
    /// Simple 2D Point structure used for rover positioning
    /// </summary>
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Creates a Point object
        /// </summary>
        /// <param name="x">X value</param>
        /// <param name="y">Y value</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Formats output for rover position output
        /// </summary>
        /// <returns>X and Y string</returns>
        public override string ToString()
        {
            return X + " " + Y;
        }
    }
}
