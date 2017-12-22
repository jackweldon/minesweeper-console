using fdb.BoardBuilders;
using fdb.Models;

namespace fdb
{
    partial class Program
    {

        static void Main(string[] args)
        {
            Bootstrap.Start();
            var builder = Bootstrap.Container.GetInstance<IGameBoardBuilder>(); 

            IGame game = new Game(builder);
            game.Run();
        }
    }
}
