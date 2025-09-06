namespace Snake.Core
{
    public interface IScoreModel
    {
        int Score { get; }
        
        void Increase(int amount);
    }
    
    public class ScoreModel : IScoreModel
    {
        public int Score { get; private set; }

        public ScoreModel(int score)
        {
            Score = score;
        }

        public void Increase(int amount)
        {
            Score += amount;
        }
    }
}