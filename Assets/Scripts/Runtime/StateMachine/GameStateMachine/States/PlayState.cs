using SnakeView.Canvas;
using Zenject;

namespace SnakeView
{
    public class PlayState : BaseState<GameState>
    {
        private readonly SignalBus _signalBus;
        private readonly IWindowService _windowService;
        private readonly ICanvasService _canvasService;

        public PlayState(SignalBus signalBus, 
            IWindowService windowService,
            ICanvasService canvasService)
        {
            _signalBus = signalBus;
            _windowService = windowService;
            _canvasService = canvasService;
        }

        public override void Enter()
        {
            _windowService.SetRoot(_canvasService.Get(CanvasType.Game).transform);

            _signalBus.Subscribe<GameOverSignal>(OnGameOver);
            
            _signalBus.Fire<LaunchGameControllerSignal>();
            
            _windowService.Add(WindowName.Hud);
        }

        private void OnGameOver(GameOverSignal obj)
        {
            _windowService.RemoveCurrent();
            
            ChangeState(GameState.GameOver);
        }

        public override void Exit()
        {
            _signalBus.Unsubscribe<GameOverSignal>(OnGameOver);
        }
    }
}