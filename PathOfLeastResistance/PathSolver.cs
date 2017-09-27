using System.Globalization;
using System.Text;

namespace PathOfLeastResistance
{
    /// <summary>
    /// Logic to solve the Path of Least Resistance challenge
    /// </summary>
    public class PathSolver
    {
        const int _maxFlow = 50;
        private int _currentCol;//the column we are currently computing
        private int _min;//minimum total resistance for the column we are currently computing
        private int _minY;//y coordinate with _min resistance in the column we are currently computing
        private readonly IWrappedGrid<GridCell> _grid;

        public PathSolver(IWrappedGrid<GridCell> grid)
        {
            _grid = grid;
        }

        /// <summary>
        /// Solves the challenge
        /// </summary>
        /// <returns></returns>
        public string Solve()
        {
            CalculateTotalResistance();
            return Output(GetPath());
        }

        /// <summary>
        /// Calculates total resistance for each cell water can reach
        /// </summary>
        private void CalculateTotalResistance()
        {
            for (_currentCol = 0; _currentCol < _grid.Width; _currentCol++)
            {
                _min = int.MaxValue;

                for (int y = 0; y < _grid.Height; y++)
                {
                    var cell = _grid.GetCell(_currentCol, y);

                    //skip first column since total resistance is initial resistance
                    if (_currentCol > 0)
                    {
                        //get cells and coordinates for all 3 cells water can flow from
                        int topY = _grid.WrapY(y - 1);
                        int bottomY = _grid.WrapY(y + 1);
                        var top = _grid.GetCell(_currentCol - 1, topY);
                        var mid = _grid.GetCell(_currentCol - 1, y);
                        var bottom = _grid.GetCell(_currentCol - 1, bottomY);
                        //is water flowing in from the top cell?
                        if (top.Value <= mid.Value && top.Value <= bottom.Value && top.Value <= _maxFlow)
                        {
                            cell.Value = top.Value + cell.Value;
                            cell.Source = topY;
                        }
                        //is water flowing in from the middle cell?
                        else if (mid.Value <= bottom.Value && mid.Value <= _maxFlow)
                        {
                            cell.Value = mid.Value + cell.Value;
                            cell.Source = y;
                        }
                        //bottom cell
                        else if (bottom.Value <= _maxFlow)
                        {
                            cell.Value = bottom.Value + cell.Value;
                            cell.Source = bottomY;
                        }
                        else//water cannot reach
                        {
                            cell.Value = int.MaxValue;
                        }
                    }
                    //keep track of the min value to output the path to see if we can continue
                    if (cell.Value < _min)
                    {
                        _min = cell.Value;
                        _minY = y;//we need the coordinate of the minimum to build the path backwards later
                    }
                }
                //if the minimum resistance is above the maximum allowed, we cannot continue
                if (_min > _maxFlow)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Returns the path the flow took
        /// depends on total resistences being calculated
        /// </summary>
        /// <returns></returns>
        private int[] GetPath()
        {
            var path = new int[_currentCol];
            //start with the lowest resistance on the right, work left building the path
            int minY = _minY;
            for (int x = _currentCol - 1; x >= 0; x--)
            {
                path[x] = minY + 1;
                var cell = _grid.GetCell(x, minY);
                minY = cell.Source;
            }
            return path;
        }

        /// <summary>
        /// Generates text to output after data has been calculated
        /// </summary>
        /// <returns></returns>
        private string Output(int[] path)
        {
            var output = new StringBuilder();
            if (_min <= _maxFlow)//Did water make it all the way through
            {
                output.AppendLine("Yes");
                output.AppendLine(_min.ToString(CultureInfo.CurrentCulture));
            }
            else
            {
                output.AppendLine("No");
                if (_currentCol == 0)
                {
                    //special case if water cannot flow at all
                    output.AppendLine("0");
                }
                else
                {
                    //need to output the value from 1 column left, since that is where the flow stopped
                    var cell = _grid.GetCell(_currentCol, _minY);//get current cell
                    cell = _grid.GetCell(_currentCol - 1, cell.Source);//get cell that flowed into the current cell
                    output.AppendLine(cell.Value.ToString(CultureInfo.CurrentCulture));
                }
            }

            output.Append(string.Join(" ", path));
            return output.ToString();
        }
    }
}
