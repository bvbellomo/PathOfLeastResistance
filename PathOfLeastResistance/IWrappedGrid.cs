namespace PathOfLeastResistance
{
    /// <summary>
    /// Represents a grid from the Path of Least Resistance challenge
    /// </summary>
    public interface IWrappedGrid<T> where T:IGridCell, new()
    {
        int Width { get; }
        int Height { get; }

        /// <summary>
        /// Returns the coordinate for x assuming the grid wraps
        /// Horizontal wrapping is not needed for the sample program
        /// </summary>
        /// <returns></returns>
        int WrapX(int x);

        /// <summary>
        /// Returns the coordinate for y assuming the grid wraps
        /// Although not needed for the sample problem, can wrap more than 1 value (e.g. -2 is valid)
        /// </summary>
        /// <returns></returns>
        int WrapY(int y);

        /// <summary>
        /// Returns the cell at x,y
        /// Does not wrap values
        /// </summary>
        /// <returns></returns>
        T GetCell(int x, int y);
    }
}
