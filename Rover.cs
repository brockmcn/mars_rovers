namespace MarsRovers
{
    /// <summary>
    /// Rover class that handles rover movement, position, and heading
    /// </summary>
    public class Rover
    {
        public Point Position { get; set; }
        public char Heading { get; set; }
        public int Rotation { get; set; }

        /// <summary>
        /// Creates a rover object
        /// </summary>
        /// <param name="position">Starting position</param>
        /// <param name="heading">Starting heading</param>
        public Rover(Point position, char heading)
        {
            Position = position;
            Heading = heading;
            SetRotation(); // Updated rotation based off starting heading
        }

        /// <summary>
        /// Method that rotates the rover based off instruction
        /// </summary>
        /// <param name="instruction">Left or right rotation instruction</param>
        public void Rotate(char instruction)
        {
            // Left rotate
            if (instruction == (char)Instructions.L)
                Rotation += 90;

            // Right Rotate
            else if (instruction == (char)Instructions.R)
                Rotation -= 90;

            // Reset rotation values if they go out of 0-270 bounds
            if (Rotation == 360)
                Rotation = 0;
            else if (Rotation == -90)
                Rotation = 270;

            SetHeading(); // Update heading
        }

        /// <summary>
        /// Method that moves the rover towards the direction it is facing
        /// </summary>
        /// <param name="grid">Inputted grid used for keeping track of bounds</param>
        public void Move(Grid grid)
        {
            Point nextPoint = Position; // Variable used to set the destination

            /*
             * Update destination based off of heading and don't let rover move out of bounds
             */
            if (Heading == 'W' && Position.X > 0)
                nextPoint.X = Position.X - 1;
            else if (Heading == 'S' && Position.Y > 0)
                nextPoint.Y = Position.Y - 1;
            else if (Heading == 'E' && Position.X < grid.Width)
                nextPoint.X = Position.X + 1;
            else if (Heading == 'N' && Position.Y < grid.Height)
                nextPoint.Y = Position.Y + 1;

            Position = nextPoint;
        }

        /// <summary>
        /// Method that updates heading based off of current rotation value
        /// </summary>
        private void SetHeading()
        {
            switch (Rotation)
            {
                case 90:
                    Heading = 'W';
                    break;
                case 180:
                    Heading = 'S';
                    break;
                case 270:
                    Heading = 'E';
                    break;
                default:
                    Heading = 'N';
                    break;
            }
        }

        /// <summary>
        /// Method that updates rotation based off of current heading value
        /// </summary>
        private void SetRotation()
        {
            switch (Heading)
            {
                case 'W':
                    Rotation = 90;
                    break;
                case 'S':
                    Rotation = 180;
                    break;
                case 'E':
                    Rotation = 270;
                    break;
                default:
                    Rotation = 0;
                    break;
            }
        }

        /// <summary>
        /// Returns rover output
        /// </summary>
        /// <returns>Rover position and heading as string</returns>
        public override string ToString()
        {
            return Position.ToString() + " " + Heading;
        }
    }
}
