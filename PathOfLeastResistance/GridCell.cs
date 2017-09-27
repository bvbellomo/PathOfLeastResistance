namespace PathOfLeastResistance
{
    public class GridCell : IGridCell
    {
        public GridCell()
        {
            Value = int.MaxValue;
        }

        /// <summary>
        /// Resistance at the cell
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Extra data to hold the y cordinate of the source of water into the cell
        /// </summary>
        public int Source { get; set; }
    }
}
