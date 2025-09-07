using Zenject;

namespace Snake
{
    public class PlayState : BaseState<GameState>
    {
        private readonly SignalBus _signalBus;
        private readonly IWindowService _windowService;

        public PlayState(SignalBus signalBus, IWindowService windowService)
        {
            _signalBus = signalBus;
            _windowService = windowService;
        }

        public override void OnEnter()
        {
            _signalBus.Subscribe<GameOverSignal>(OnGameOver);
            
            _signalBus.Fire<LaunchGameControllerSignal>();
            
            _windowService.Add(WindowName.Hud);
        }

        private void OnGameOver(GameOverSignal obj)
        {
            _windowService.RemoveCurrent();
            
            ChangeState(GameState.GameOver);
        }

        public override void OnExit()
        {
            _signalBus.Unsubscribe<GameOverSignal>(OnGameOver);
        }
    }
}