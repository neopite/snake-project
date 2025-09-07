namespace Snake.Core
{
    public class ScoreModel : IScoreModel
    {
        public int Score { get; private set; }
        
        public void Increase(int amount)
        {
            Score += amount;
        }
    }
}