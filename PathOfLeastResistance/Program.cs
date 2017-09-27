using System;
using System.IO;

namespace PathOfLeastResistance
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                var input = File.ReadAllLines(args[0]);
                string output = new PathSolver(new WrappedGrid<GridCell>(input)).Solve();
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine(@"Solves the Path of Least Resistance challenge from FormFire.");
                Console.WriteLine();
                Console.WriteLine(@"usage: PathOfLeastResistance [drive:][path][filename]");
                Console.WriteLine(@"e.g. PathOfLeastResistance c:\temp\input.txt, PathOfLeastResistance input.txt, etc.");
                Console.WriteLine();
                Console.WriteLine(@"See readme.txt for details on problem description and input file format.");
                Console.WriteLine();
            }
        }
    }
}
