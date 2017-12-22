using fdb.Models;

namespace fdb.BoardBuilders
{
    public class MinesweeperBoardBuilder : IGameBoardBuilder
    {
        public IBoard Build(int height, int width)
        {
            return new Board(new Square[width,height]);
        }
    }

}
