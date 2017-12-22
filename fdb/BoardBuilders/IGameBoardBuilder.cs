using fdb.Models;

namespace fdb.BoardBuilders
{
    public interface IGameBoardBuilder
    {
        IBoard Build(int height, int width);
    }
}