using System;

namespace Snake.Core
{
    public class ScoreModel : IScoreModel
    {
        public event Action<int> OnScoreChanged;
        public int Score { get; private set; }
        
        public void Increase(int amount)
        {
            Score += amount;
            
            OnScoreChanged?.Invoke(Score);
        }

        public void Reset()
        {
            Score = 0;
        }
    }
}