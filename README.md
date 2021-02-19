# Mars Rovers

## Project Description
NASA intends to land robotic rovers on Mars to explore a particularly curious-looking plateau. The rovers must
navigate this rectangular plateau in a way so that their on board cameras can get a complete image of the
surrounding terrain to send back to Earth.

A simple two-dimensional coordinate grid is mapped to the plateau to aid in rover navigation. Each point on the
grid is represented by a pair of numbers X Y which correspond to the number of points East or North, respectively,
from the origin. The origin of the grid is represented by 0 0 which corresponds to the southwest corner of the
plateau. 0 1 is the point directly north of 0 0, 1 1 is the point immediately east of 0 1, etc. A rover’s current
position and heading are represented by a triple X Y Z consisting of its current grid position X Y plus a letter Z
corresponding to one of the four cardinal compass points, N E S W. For example, 0 0 N indicates that the rover is
in the very southwest corner of the plateau, facing north.

NASA remotely controls rovers via instructions consisting of strings of letters. Possible instruction letters are L,
R, and M. L and R instruct the rover to turn 90 degrees left or right, respectively (without moving from its current
spot), while M instructs the rover to move forward one grid point along its current heading.

This application takes test input (instructions from NASA) and provides the expected
output (the feedback from the rovers to NASA). Each rover moves in series, i.e. the next rover will not start
moving until the one preceding it finishes.

Input: Assume the southwest corner of the grid is 0,0 (the origin). The first
line of input establishes the exploration grid bounds by indicating
the coordinates corresponding to the northeast corner of the
plateau. Next, each rover is given its instructions in turn. Each rover’s
instructions consists of two lines of strings. The first string confirms
the rover’s current position and heading. The second string consists
of turn / move instructions.

Output: Once each rover has received and completely executed its given
instructions, it transmits its updated position and heading to NASA.

## Design Explanation

1. Take inputs through the command line. Accepted formats are 2 files (input and output) or the input directly passed in as arguments. 

2. Create the grid with inputted width and height values. This does not need to be a 2D array since there are no values that need to be returned or accessed from the grid. Instead, I use a point class, which just stores a 2D position. This approach is easier to implement and more efficient because only points that are needed are created, rather than grid points that are never accessed. 

3. Create a rover object with the starting position and heading indicated by inputted values. The rover holds its current position and rotation that are updated after each instruction that affects it.

4. Run through instructions character by character. Instructions have been uploaded to an enum for readability and to make it easy to add new instructions should the program be updated.

5. Output updated position and heading to output file or console.

6. Repeat process for each rover.

## Assumptions

I assume that people can make mistakes and accidentally provide incorrect inputs, therefore this program handles errors and gives the user feedback.
