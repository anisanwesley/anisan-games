using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeD.Sudoku.Algoritmo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(
            new SudokuSolver("710820904" +
                             "008006050" +
                             "240003010" +
                             "650049081" +
                             "470038092" +
                             "000100400" +
                             "120004060" +
                             "009007040" +
                             "830650709",true).Solve());
            new SudokuSolver("000000000" +
                          "000000000" +
                          "000000000" +
                          "000000000" +
                          "000000000" +
                          "000000000" +
                          "000000000" +
                          "000000000" +
                          "000000000",false).Solve();
          
            Console.Read();

        }

    }
}
