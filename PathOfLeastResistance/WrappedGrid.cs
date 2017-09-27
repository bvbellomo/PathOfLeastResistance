using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PathOfLeastResistance
{
    /// <summary>
    /// Implements a wrapped grid
    /// </summary>
    public class WrappedGrid<T> : IWrappedGrid<T> where T:IGridCell, new()
    {
        private static readonly char[] _lineDelimiters = {'\r', '\n'};

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        
        private readonly int _width;
        private readonly int _height;
        private readonly T[][] _cells;

        public WrappedGrid(string input)
            : this(input.Split(_lineDelimiters, StringSplitOptions.RemoveEmptyEntries))
        {
        }

        public WrappedGrid(string[] lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException("lines");
            }
            
            _height = lines.Length;
            if (Height < 1)
            {
                throw new ArgumentException("One valid line is required", "lines");
            }

            _cells = new T[Height][];
            for (int i = 0; i < Height; i++)
            {
                _cells[i] = Array.ConvertAll(lines[i].Split(' '), x => new T { Value = int.Parse(x) });
            }

            _width = _cells[0].Length;
            if (Width < 1)
            {
                throw new ArgumentException("One valid line is required", "lines");
            }
        }

        /// <summary>
        /// Public method to view the values of the grid
        /// Useful for debugging, but not needed for the program
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            var output  = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                var line = _cells[y].Select(x => x.Value.ToString(CultureInfo.CurrentCulture));
                output.AppendLine(string.Join("\t", line));
            }
            return output.ToString();
        }

        /// <summary>
        /// Returns the coordinate for x assuming the grid wraps
        /// Horizontal wrapping is not needed for the sample program
        /// </summary>
        /// <returns></returns>
        public int WrapX(int x)
        {
            //x % Width only works for positive values, the code below works for any integer
            return ((x % Width) + Width) % Width;
        }

        /// <summary>
        /// Returns the coordinate for y assuming the grid wraps
        /// Although not needed for the sample problem, can wrap more than 1 value (e.g. -2 is valid)
        /// </summary>
        /// <returns></returns>
        public int WrapY(int y)
        {
            return ((y % Height) + Height) % Height;
        }

        /// <summary>
        /// Returns the cell at x,y
        /// Does not wrap values
        /// </summary>
        /// <returns></returns>
        public T GetCell(int x, int y)
        {
            //do no check valid coordinates, relies on the array to throw Exception for invalid values
            return _cells[y][x];
        }
    }
}
