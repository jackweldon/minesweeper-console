namespace fdb.Models
{
    public interface IBoard
    {
        ISquare[,] Squares { get; set; } 
        ISquare GetCurrentLocation();
        void Draw();
        bool Move(char direction);
    }
}