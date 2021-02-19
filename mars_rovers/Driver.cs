using System;
using System.IO;

namespace MarsRovers
{
    /// <summary>
    /// The main class that takes the input, runs the program, and presents the output
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Main method that simulates the entire program
        /// </summary>
        /// <param name="args">File or arguments input</param>
        static public void Main(string[] args)
        {
            bool isFile = false;  // If the input is a file
            string[] input = args; // This is used so that inputs can be parsed if it is a file input


            // If correct file input format
            if (args.Length == 2)
            {
                /*
                 * Try reading in every line from the input file and then parsing it to match argument format
                 */
                try
                {
                    string[] lines = File.ReadAllLines(args[0]);
                    string fileInput = "";
                    for (int i = 0; i < lines.Length; i++)
                        fileInput += lines[i] + " ";
                    input = fileInput.Split(' ');
                    isFile = true;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
            }


            // If the argument input is valid or it is a valid file input
            if (ValidInput(args) || isFile)
            {
                try
                {
                    int width = int.Parse(input[0]);
                    int height = int.Parse(input[1]);

                    if (width <= 0 || height <= 0)
                    {
                        Console.WriteLine("Height and width values must be greater than 0");
                        throw new FormatException();
                    }

                    Grid grid = new Grid(width, height);

                    int numRovers = (input.Length - 2) / 4;


                    // Run through program for each rover
                    for (int i = 0; i < numRovers; i++)
                    {
                        int x = int.Parse(input[2 + (i * 4)]);
                        int y = int.Parse(input[3 + (i * 4)]);
                        char heading = char.Parse(input[4 + (i * 4)]);

                        if (!ValidRover(width, height, x, y, heading))
                        {
                            Console.WriteLine("Invalid rover starting position/heading");
                            throw new FormatException();
                        }

                        Point startingPosition = new Point(x, y);

                        Rover rover = new Rover(startingPosition, heading);

                        string instructions = input[5 + (i * 4)];


                        // Handle instructions
                        foreach (char instruction in instructions)
                        {
                            if (instruction == (char)Instructions.L || instruction == (char)Instructions.R)
                                rover.Rotate(instruction);
                            else if (instruction == (char)Instructions.M)
                                rover.Move(grid);
                        }

                        // If the file argument format was chosen, output to file
                        if (isFile)
                        {
                            if (i == 0)
                                File.WriteAllText(args[1], rover.ToString());
                            else
                                File.AppendAllText(args[1], '\n' + rover.ToString());
                        }
                        // If command line argument format was chosen, output to console
                        else
                            Console.WriteLine(rover.ToString());
                    }
                }
                catch (FormatException)
                {
                    Console.Write("Inputs are not the correct format");
                }                
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Input can be command line arguments with the following format: <grid_width> <grid_height> <rover_x_position> <rover_y_position> <rover_heading> <instructions>");
                Console.WriteLine("Input can be a input and output file with the following format: <input_file> <output_file>");
            }
        }

        /// <summary>
        /// Helper method to make sure that arguments match correct format
        /// </summary>
        /// <param name="input">User input arguments</param>
        /// <returns>If the argument format is valid</returns>
        static private bool ValidInput(string[] input)
        {
            return (input.Length >= 6 && (input.Length - 2) % 4 == 0);
        }

        /// <summary>
        /// Helper method that ensures the rover created is valid
        /// </summary>
        /// <param name="w">Width of the grid</param>
        /// <param name="h">Height of the grid</param>
        /// <param name="x">X position of rover</param>
        /// <param name="y">Y position of rover</param>
        /// <param name="heading">Heading of rover</param>
        /// <returns>If rover's starting position and heading is valid</returns>
        static private bool ValidRover(int w, int h, int x, int y, char heading)
        {
            return x >= 0 && x <= w && y >= 0 && y <= h && (heading == 'L' || heading == 'R' || heading == 'M');
        }
    }
}