using Zenject;

namespace Snake
{
    public class GameOverPresenter : BaseWindowPresenter<GameOverWindow>
    {
        public GameOverPresenter(SignalBus signalBus) : base(signalBus)
        {
        }

        public override void Initialize()
        {
            Window.PlayAgainButtonOnClick.AddListener(OnPlayAgainPressed);
        }

        private void OnPlayAgainPressed()
        {
            Window.Close();
            SignalBus.Fire<PlayAgainSignal>();
        }

        public override void Dispose()
        {
            Window.PlayAgainButtonOnClick.RemoveAllListeners();
        }
    }
}