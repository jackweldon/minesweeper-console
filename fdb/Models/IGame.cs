namespace fdb.Models
{
    public interface IGame
    {
        bool Finished { get; }
        int MineCount { get; set; }

        void Run();
    }
}