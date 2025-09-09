using Snake.Core;
using Zenject;

namespace SnakeView
{
    public class GameOverPresenter : BaseWindowPresenter<GameOverWindow>
    {
        private readonly IReadOnlyScoreModel _scoreModel;
        public GameOverPresenter(
            SignalBus signalBus,
            IReadOnlyScoreModel scoreModel) : base(signalBus)
        {
            _scoreModel = scoreModel;
        }

        public override void Initialize()
        {
            Window.PlayAgainButtonOnClick.AddListener(OnPlayAgainPressed);
            
            Window.SetScore(_scoreModel.Score);
        }

        private void OnPlayAgainPressed()
        {
            Window.Close();
            SignalBus.Fire<PlayAgainSignal>();
        }

        public override void Dispose()
        {
            Window?.PlayAgainButtonOnClick?.RemoveAllListeners();
        }
    }
}