using System;

namespace Snake.Core
{
    public interface IScoreModel : IReadOnlyScoreModel
    {
        void Increase(int amount);
        void Reset();
    }

    public interface IReadOnlyScoreModel : IScoreModelEvents
    {
        int Score { get; }
    }

    public interface IScoreModelEvents
    {
        event Action<int> OnScoreChanged;
    }
}