using Snake.Core;
using Zenject;

namespace Snake
{
    public class HudWindowPresenter : BaseWindowPresenter<HudWindow>
    {
        private IScoreModel _scoreModel;
        
        public HudWindowPresenter(SignalBus signalBus, IScoreModel scoreModel) : base(signalBus)
        {
            _scoreModel = scoreModel;
        }

        public override void Initialize()
        {
            _scoreModel.OnScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int newScore)
        {
            Window.SetScore(newScore);
        }

        public override void Dispose()
        {
            _scoreModel.OnScoreChanged -= OnScoreChanged;
        }
    }
}