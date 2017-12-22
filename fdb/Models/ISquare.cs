namespace fdb.Models
{
    public interface ISquare
    {
        bool IsHit { get; set; }
        bool IsMine { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
    }
}