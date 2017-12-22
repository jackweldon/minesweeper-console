using System;

namespace fdb.Models
{
    public class Board : IBoard
    {
        public ISquare[,] Squares { get; set; }

        private int _userCurrentRow;
        private int _userCurrentColumn;

        public Board(Square[,] squares)
        {
            Squares = squares;
            InitializeBoard();
        }

        public ISquare GetCurrentLocation()
        {
            return Squares[_userCurrentRow, _userCurrentColumn];

        }
        /// <summary>
        /// move the current position in the direction specified
        /// </summary>
        /// <param name="direction">U, L, D ,R</param>
        /// <returns>True if a mine has been hit</returns>
        public bool Move(char direction)
        {
            switch (Char.ToUpper(direction))
            {
                case 'R':
                    _userCurrentColumn++;
                    break;
                case 'L':
                    _userCurrentColumn--;
                    break;
                case 'U':
                    _userCurrentRow--;
                    break;
                case 'D':
                    _userCurrentRow++;
                    break;
            }

            GetCurrentLocation().IsHit = true;

            if (GetCurrentLocation().IsMine)
                return true;

            return false;
        }

        private void InitializeBoard()
        {
            for (int x = 0; x < Squares.GetLength(0); x++)
            {
                for (int y = 0; y < Squares.GetLength(1); y++)
                {
                   var square= new Square
                   {
                       PositionX = x,
                       PositionY = y
                   }; 

                    Squares[y, x] = square;
                }

            }
            _userCurrentRow = GameSettings.BOARD_HEIGHT - 1; //start at the bottom
            GetCurrentLocation().IsHit = true; // initilze first sqaure
            PopulateMines();
        }
        private void PopulateMines()
        {
            var mineCount = 0;
            var random = new Random();
            while (mineCount < GameSettings.NUMBER_OF_MINES)
            {
                int randomColumn = random.Next(0, GameSettings.BOARD_HEIGHT);
                int randomRow = random.Next(0, GameSettings.BOARD_WIDTH);

                if (randomRow == 0 && randomColumn == 0) //dont want to start on any mines! 
                    continue;
                if (Squares[randomRow, randomColumn].IsMine) //already is a mine
                    continue;

                Squares[randomRow, randomColumn].IsMine = true;
                mineCount++;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < Squares.GetLength(0); i++)
            {
                for (int j = 0; j < Squares.GetLength(1); j++)
                {
                    Console.Write(Squares[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("            ");

            Console.WriteLine("Please press U, D, L or R");
        }
    }
}