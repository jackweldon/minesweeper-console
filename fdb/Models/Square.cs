namespace fdb.Models
{
    public class Square : ISquare
    {
        public bool IsMine { get; set; }

        public bool IsHit { get; set; }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public override string ToString()
        {
            if (IsHit)
            {
                return IsMine ? "B" : "X";
            }

            return "O";
        }
    }
}