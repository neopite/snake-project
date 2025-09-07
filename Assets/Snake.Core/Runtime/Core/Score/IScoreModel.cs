namespace Snake.Core
{
    public interface IScoreModel
    {
        int Score { get; }
        
        void Increase(int amount);
    }
}