﻿Solves the path of least resistance sample program from FormFire.

The Challenge

Water flows through the path of least resistance. For this challenge, you are provided a grid of integers
where each integer represents the amount of resistance encountered at a given point on the grid. Water
enters the grid from the left (at any point) and passes through the grid to the right, moving only one
column per round. Movement is always to an adjacent row; meaning water can flow horizontally or
diagonally. For the sake of this challenge, we assume the first and last row are also adjacent. Effectively,
the grid “wraps”.

The total resistance of a path is the sum of the integers in each of the visited cells. The solution needs to
handle grids of various sizes with a minimum of 1 row and 5 columns up to 10 rows and 100 columns. If
in the next move, the total resistance will exceed 50, the water cannot continue.
The minimum paths through two slightly different 5 x 6 grids are shown below. The grid values differ
only in the bottom row. The path for the grid on the right takes advantage of the adjacency between the
first and last rows.

Input

The input consists of a sequence of row specifications. Each row is represented by a series of delimited
integers on a single line. Note: integers are not restricted to being positive.


Output

Three lines should be output for each matrix specification. The first line is either yes or no to indicate the
water made it all the way through the grid. The second line is the total resistance. The third line shows
the path taken as a sequence of n delimited integers, each representing the rows traversed in turn. If
there is more than one path of least resistance, only one path need be shown in the solution.


Notes

This program was implemented as a .NET 4.5 console application in C# with Visual Studio 2012.  This was chosen based on the technology in the FormFire job description, the problem statement and the setup of my machine.

This program can be run command line with an input file, e.g. PathOfLeastResistance c:\temp\input.txt, PathOfLeastResistance input.txt, etc.  Unit tests for the example problems are also included.

Several classes implement a wrapped grid that can be resused with a different problem, however only integer values are supported.

IWrappedGrid - an interface defining operations to implement a wrapped grid with integer values;
WrappedGrid - implementation of IWrappedGrid, could be reused for other problems with similar input format
IGridCell - interface for a integer grid cell
GridCell - implementation of IGridCell for the path of least resistance challenge.
PathSolver - implementation of logic to solve the least resistance challenge.
Program - implementation to run from command line input

This is arguably too many classes for a simple project, and not an optimal solution for speed or memory.  With only a requirement to support 10 rows and 100 columns, there is no reason to consider speed or memory.  I could have produced 1 file with several functions and solved the problem in fewer lines of code.  The current solution is just as readable and more exensible, and seemed more in the spirit of what FormFire wanted.

Assumptions:
1) No checking is done for grids larger than 10x100 was done.  No requirement was given to fail for larger grids, just that grids up to this size should be supported.  The code is simpler and more resusable without this check.
2) The requirement "If in the next move, the total resistance will exceed 50, the water cannot continue" is taken literally.  Even though negative numbers are allowed, no path ending with a resistance less than 50 is allowed if it goes above 50 at any point.  This is how water would behave on a slope.  Water in a pipe behaves differently - if the end of the pipe is below the start, water can flow even if the middle is higher.


Author: Brad Bellomo
Date: 9/27/2017