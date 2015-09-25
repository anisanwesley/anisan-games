using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Program
    {

        static Board board;
        static Random rnd;

        static void Main(string[] args)
        {

            Init();
            Refresh();

            var result = Result.Playing;

            for (var input = ""; input != "sair"; Refresh())
            {

                input = Console.ReadLine();

                if (Play(input))
                    Play();

                result = board.GameResult;

                if (result != Result.Playing)
                {
                    Console.WriteLine("\nResultado: " + result.ToString());
                    Console.ReadKey();

                    Init();
                }
            }
        }

        private static void Init()
        {
            rnd = new Random();

            board = Velha.Create();
            board.Areas = Velha.Create(board.Squares);
        }
           

        

        [System.Diagnostics.DebuggerStepThrough]
        private static void Refresh()
        {
            Console.Clear();
            Console.WriteLine("Digite a coluna e linha de onde quer jogar neste formato: 'x,y'. Exemplo: 2,1");
            Console.WriteLine("Digite 'sair' para sair");

            Console.WriteLine(" - | 1 | 2 | 3");
            Console.WriteLine(" 1 |[{0}]|[{1}]|[{2}]"
                , board.Squares.First(x => x.PX == 1 && x.PY == 1).Toe
                , board.Squares.First(x => x.PX == 1 && x.PY == 2).Toe
                , board.Squares.First(x => x.PX == 1 && x.PY == 3).Toe
                );
            Console.WriteLine(" 2 |[{0}]|[{1}]|[{2}]"
                , board.Squares.First(x => x.PX == 2 && x.PY == 1).Toe
                , board.Squares.First(x => x.PX == 2 && x.PY == 2).Toe
                , board.Squares.First(x => x.PX == 2 && x.PY == 3).Toe
                );
            Console.WriteLine(" 3 |[{0}]|[{1}]|[{2}]"
                , board.Squares.First(x => x.PX == 3 && x.PY == 1).Toe
                , board.Squares.First(x => x.PX == 3 && x.PY == 2).Toe
                , board.Squares.First(x => x.PX == 3 && x.PY == 3).Toe
                );
        }

        //Play com comando parametrizado, é o player jogando
        private static bool Play(string command)
        {
            var split = command.Split(',');

            try
            {

                var x = Convert.ToInt32(split[0]);
                var y = Convert.ToInt32(split[1]);

                var square = board.Squares.First(a => a.PX == x && a.PY == y);
                
				 if (square.Toe != Toe._) return false;
				 
				 square.Toe = Toe.X;

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Threading.Thread.Sleep(3000);
                return false;
            }
        }

        //Play sem comando, é o pc jogando
        private static void Play()
        {
            var almosts = board.Areas.FindAll(a => a.Almost == Toe.O);
            almosts.AddRange(board.Areas.FindAll(a => a.Almost == Toe.X));

            if (almosts.Count==0)
            {
               var avaliable =  board.Squares.FindAll(x => x.Toe == Toe._);
			   
			     if (avaliable.Count == 0) return;
				 
                avaliable[rnd.Next(0, avaliable.Count - 1)].Toe = Toe.O;
            }
            else
            {
                almosts.First().Complete();
            }




        }
    }

    public static class Velha
    {
        public static Board Create()
        {
            var board = new Board();

            for (int x = 1; x <= 3; x++)
                for (int y = 1; y <= 3; y++)
                    board.Squares.Add(new Square(x, y));


            return board;
        }

        internal static List<Area> Create(List<Square> squares)
        {
            var areas = new List<Area>();

            areas.AddRange(Horizontal(squares));
            areas.AddRange(Vertical(squares));
            areas.Add(DiagonalX(squares));
            areas.Add(DiagonalY(squares));




            return areas;
        }

        private static Area DiagonalX(List<Square> squares)
        {
            var result = new List<Square>();
            const int quatro = 4;
            for (int i = 1; i <= 3; i++)
                result.Add(squares.Find(x => x.PX == i && x.PY == quatro - i));
            return new Area(result);
        }
        private static Area DiagonalY(List<Square> squares)
        {
            return new Area(squares.FindAll(x => x.PX == x.PY));
        }

        private static IEnumerable<Area> Vertical(List<Square> squares)
        {
            for (int i = 1; i <= 3; i++)
                yield return new Area(squares.FindAll(x => x.PY == i));

        }

        private static IEnumerable<Area> Horizontal(List<Square> squares)
        {
            for (int i = 1; i <= 3; i++)
                yield return new Area(squares.FindAll(x => x.PX == i));

        }

    }

    public class Board
    {
        public List<Area> Areas = new List<Area>();
        public List<Square> Squares = new List<Square>();

        public Result GameResult {
            get
            {
			
			 if (Areas.All(x => x.Full))
                    return Result.Draw;
					
                if (Areas.Any(x => x.Finished))
                {
                    return GetWinner();
                }

                return Result.Playing;

            }

        }

        private Result GetWinner()
        {
            var winner = Areas.Any(x => x.Squares.All(y => y.Toe == Toe.X));

            return winner ? Result.Victory : Result.Defeated;


        }
    }

    public class Area
    {
        public List<Square> Squares;

        public Area(List<Square> squares)
        {
            Squares = squares;
        }

        public Toe Almost
        {
            get {
                if (Squares.Count(s => s.Toe == Toe._) == 0) return Toe._;

                if (Squares.Count(s => s.Toe == Toe.O) == 2) return Toe.O;

                if(Squares.Count(s => s.Toe == Toe.X) == 2) return Toe.X;

                return Toe._;

            }
        }

      public bool Finished
        {
            get
            {
                return Squares[0].Toe == Squares[1].Toe && Squares[1].Toe == Squares[2].Toe && Squares[0].Toe != Toe._;
            }
        }
        public bool Full
        {
            get
            {
                return Squares.All(x => x.Toe != Toe._);
            }
        }

        public override string ToString()
        {
            var s = "";
            foreach (var item in Squares)
                s += item.ToString().Split('-')[0];
            return s;

        }

        internal void Complete()
        {
            var square= Squares.FirstOrDefault(x => x.Toe == Toe._).Toe = Toe.O;
        }
    }
    public class Square
    {
        public int PY { get; private set; }
        public int PX { get; private set; }
        public Toe Toe { get; set; }

        public Square(int px, int py)
        {
            PX = px; PY = py;
        }
        public override string ToString()
        {
            return string.Format("[{0},{1}] - [{2}]", PX, PY, Toe);
        }
    }

    public enum Toe
    {
        _, X, O
    }

    public enum Result
    {
        Playing, Victory, Defeated, Draw
    }

}
