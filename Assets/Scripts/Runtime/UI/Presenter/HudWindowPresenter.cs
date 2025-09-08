using Snake.Core;
using Zenject;

namespace Snake
{
    public class HudWindowPresenter : BaseWindowPresenter<HudWindow>
    {
        private IScoreModelEvents _scoreModelEvents;
        
        public HudWindowPresenter(SignalBus signalBus, IScoreModelEvents scoreModelEvents) : base(signalBus)
        {
            _scoreModelEvents = scoreModelEvents;
        }

        public override void Initialize()
        {
            _scoreModelEvents.OnScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int newScore)
        {
            Window.SetScore(newScore);
        }

        public override void Dispose()
        {
            _scoreModelEvents.OnScoreChanged -= OnScoreChanged;
        }
    }
}