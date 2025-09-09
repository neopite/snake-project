using Zenject;

namespace SnakeView
{
    public class MainMenuWindowPresenter : BaseWindowPresenter<MainMenuWindow>
    {
        public MainMenuWindowPresenter(SignalBus signalBus) : base(signalBus)
        {
        }

        public override void Initialize()
        {
            Window.StartButtonOnClick.AddListener(OnStartButtonClick);
            Window.ExitButtonOnClick.AddListener(OnExitButtonClick);
        }

        private void OnStartButtonClick()
        {
            Window.Close();
            SignalBus.Fire<LoadLevelSignal>();
        }

        private void OnExitButtonClick()
        {
            Window.Close();
            SignalBus.Fire<ExitApplicationSignal>();
        }

        public override void Dispose()
        {
            Window.StartButtonOnClick.RemoveAllListeners();
            Window.ExitButtonOnClick.RemoveAllListeners();
        }
    }
}