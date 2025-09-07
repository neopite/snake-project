using System;

namespace Snake.Core
{
    public interface IScoreModel
    {
        event Action<int> OnScoreChanged;
        int Score { get; }
        void Increase(int amount);
        void SetScore(int score);
    }
}