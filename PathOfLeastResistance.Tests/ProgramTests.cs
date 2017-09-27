using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PathOfLeastResistance.Tests
{
    /// <summary>
    /// Program level tests for the Path of Least Resistance challenge excercise
    /// If adding tests that apply to one class only, add a new TestClass
    /// </summary>
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleOneWorks()
        { 
            const string input = @"3 4 1 2 8 6
6 1 8 2 7 4
5 9 3 9 9 5
8 4 1 3 2 6
3 7 2 8 6 4";

            const string expected = @"Yes
16
1 2 3 4 4 5";

            var grid = new WrappedGrid<GridCell>(input);
            string output = new PathSolver(grid).Solve();
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ExampleTwoWorks()
        {
            const string input = @"3 4 1 2 8 6
6 1 8 2 7 4
5 9 3 9 9 5
8 4 1 3 2 6
3 7 2 1 2 3";

            const string expected = @"Yes
11
1 2 1 5 4 5";

            var grid = new WrappedGrid<GridCell>(input);
            string output = new PathSolver(grid).Solve();
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ExampleThreeWorks()
        {
            const string input = @"19 10 19 10 19
21 23 20 19 12
20 12 20 11 10";

            const string expected = @"No
48
1 1 1";

            var grid = new WrappedGrid<GridCell>(input);
            string output = new PathSolver(grid).Solve();
            Assert.AreEqual(expected, output);
        }

        /// <summary>
        /// Additional test for the case where water cannot flow into the first column
        /// </summary>
        [TestMethod]
        public void HighFirstColWorks()
        {
            const string input = @"59 -10 19 10 19
61 23 20 19 12
70 12 20 11 10";

            const string expected = @"No
0
";
            var grid = new WrappedGrid<GridCell>(input);
            string output = new PathSolver(grid).Solve();
            Assert.AreEqual(expected, output);
        }

        /// <summary>
        /// Additional test for the case where water cannot flow past a max value even with negatives further down
        /// This assumes water flows as if we are on a slope, not as if it is in a pipe that can syphon
        /// This assumption is based on the wording of the problem statement
        /// </summary>
        [TestMethod]
        public void HighFlowBeforeNegativeWorks()
        {
            const string input = @"1 1 49 -10
50 50 50 50
10 10 10 21
50 50 50 50";

            const string expected = @"No
30
3 3 3";
            var grid = new WrappedGrid<GridCell>(input);
            string output = new PathSolver(grid).Solve();
            Assert.AreEqual(expected, output);
        }
    }
}
