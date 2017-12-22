using System;
using fdb.BoardBuilders;
using fdb.Models;

namespace fdb
{
    public class Game : IGame
    {
        private IBoard GameBoard { get; set; }

        public int MineCount { get; set; }
        public bool Finished => MineCount >= 2 || GameBoard.GetCurrentLocation().PositionY == 0;

        public Game(IGameBoardBuilder builder)
        {
            GameBoard = builder.Build(GameSettings.BOARD_HEIGHT, GameSettings.BOARD_WIDTH);
        }

        public void Run()
        {
            while (!Finished)
            {
                Draw();
                var input = Console.ReadKey().KeyChar;

                var mineHit = GameBoard.Move(input);

                if (mineHit)
                    MineCount++;
            }
            if (Finished)
            {
                Draw();
                Console.WriteLine(MineCount >= 2 ? "Game over" : "Game complete");
                Console.ReadLine();
            }
        }

        private void Draw()
        {
            Console.Clear();
            PrintHeader();

            GameBoard.Draw();
        }

        private void PrintHeader()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Press the Escape (Esc) key to quit".PadRight(120));

            Console.WriteLine("Current Position: ");
            Console.WriteLine("Row:    {0}", GameBoard.GetCurrentLocation().PositionX);
            Console.WriteLine("Column: {0}", GameBoard.GetCurrentLocation().PositionY);
            Console.WriteLine("            ");
            Console.WriteLine("Bombs Hit: {0}", MineCount);
            Console.WriteLine("            ");
        }


    }
}