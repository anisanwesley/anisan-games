using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeD.Sudoku.Algoritmo
{
    public class SudokuSolver
    {
        private readonly int[] _grid;
        private readonly bool _criando;//oposto de 'resolvendo'

        public SudokuSolver(String s,bool criando)
        {
            _criando = criando;
            _grid = new int[81];
            for (var i = 0; i < s.Length; i++)
                _grid[i] = int.Parse(s[i].ToString());
        }

        public string Solve()
        {
            try
            {
                PlaceNumber(0);
                return("Impossivel!");
            }
            catch (Exception ex)
            {
                return (this.ToString(_criando));
            }
        }

        public void PlaceNumber(int pos)
        {
            if (pos == 81) throw new Exception("Finished!");

            if (_grid[pos] > 0) PlaceNumber(pos + 1);

            else
                for (var n = 1; n <= 9; n++)
                {
                    if (!CheckValidity(n, pos%9, pos/9)) continue;

                    _grid[pos] = n;
                    PlaceNumber(pos + 1);
                    _grid[pos] = 0;
                }

        }

        public bool CheckValidity(int val, int x, int y)
        {
            for (var i = 0; i < 9; i++)
            {
                if (_grid[y*9 + i] == val || _grid[i*9 + x] == val)
                    return false;
            }
            var startX = (x/3)*3;
            var startY = (y/3)*3;
            for (var i = startY; i < startY + 3; i++)
                for (var j = startX; j < startX + 3; j++)
                    if (_grid[i*9 + j] == val)
                        return false;
            return true;
        }

        public string ToString(bool criando)
        {
            var matrix = new int[9,9];
            var sb = new StringBuilder("");
            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                    matrix[i, j] = _grid[i*9 + j];

            int fC = 0;//First char  = A = 65;

            for (var l = 1; l <= 9; l++)//linhas
            {
                for (var c = 1; c <= 9; c++) //colunas
                {

                    if (l < 4 && c < 4) fC = 65;
                    if (l < 4 && c > 3 && c < 7) fC = 66;
                    if (l < 4 && c > 6) fC = 67;

                    if (l > 3 && l < 7 && c < 4) fC = 68;
                    if (l > 3 && l < 7 && c > 3 && c < 7) fC = 69;
                    if (l > 3 && l < 7 && c > 6) fC = 70;

                    if (l > 6 && c < 4) fC = 71;
                    if (l > 6 && c > 3 && c < 7) fC = 72;
                    if (l > 6 && c > 6) fC = 73;

                    sb.Append(String.Format("Q{0}_L{1}_C{2}:{3}:{4}\n"
                        ,((char)fC),l,c,matrix[(l-1),(c-1)],criando));
                  
                }
            }

            return sb.ToString();

        }
    }
}

//-=-=-=-ORIGINAL-=-=-=-//

        // private readonly int[] grid;

        //public SudokuSolver(String s)
        //{
        //    grid = new int[81];
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        grid[i] = int.Parse(s[i].ToString());
        //    }
        //}

        //public void solve()
        //{
        //    try
        //    {
        //        placeNumber(0);
        //        Console.WriteLine("Unsolvable!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.WriteLine(this);
        //    }
        //}

        //public void placeNumber(int pos)
        //{
        //    if (pos == 81)
        //    {
        //        throw new Exception("Finished!");
        //    }
        //    if (grid[pos] > 0)
        //    {
        //        placeNumber(pos + 1);
        //        return;
        //    }
        //    for (int n = 1; n <= 9; n++)
        //    {
        //        if (checkValidity(n, pos%9, pos/9))
        //        {
        //            grid[pos] = n;
        //            placeNumber(pos + 1);
        //            grid[pos] = 0;
        //        }
        //    }
        //}

        //public bool checkValidity(int val, int x, int y)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (grid[y*9 + i] == val || grid[i*9 + x] == val)
        //            return false;
        //    }
        //    int startX = (x/3)*3;
        //    int startY = (y/3)*3;
        //    for (int i = startY; i < startY + 3; i++)
        //    {
        //        for (int j = startX; j < startX + 3; j++)
        //        {
        //            if (grid[i*9 + j] == val)
        //                return false;
        //        }
        //    }
        //    return true;
        //}

        //public  string ToStdring()
        //{
        //    string sb = "";
        //    for (int i = 0; i < 9; i++)
        //    {
        //        for (int j = 0; j < 9; j++)
        //        {
        //            sb += (grid[i*9 + j] + " ");
        //            if (j == 2 || j == 5)
        //                sb += ("| ");
        //        }
        //        sb += ('\n');
        //        if (i == 2 || i == 5)
        //            sb += ("------+-------+------\n");
        //    }
        //    return sb;
       

    

