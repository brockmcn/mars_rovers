namespace MarsRovers
{
    /// <summary>
    /// Grid that sets bounds for rover positioning and movement
    /// </summary>
    public class Grid
    {
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// Creates new Grid object
        /// </summary>
        /// <param name="width">Width of grid</param>
        /// <param name="height">Height of grid</param>
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
