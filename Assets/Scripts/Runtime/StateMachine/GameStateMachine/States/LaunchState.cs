using SnakeView.Canvas;

namespace SnakeView
{
    public class LaunchState : BaseState<GameState>
    {
        private readonly IWindowProvider _windowProvider;
        private readonly IWindowService _windowService;
        private readonly ICanvasService _canvasService;

        public LaunchState(
            IWindowProvider windowProvider,
            ICanvasService canvasService,
            IWindowService windowService)
        {
            _windowProvider = windowProvider;
            _canvasService = canvasService;
            _windowService = windowService;
        }

        public async override void Enter()
        {
            await _windowProvider.Load();
            
            _windowService.SetRoot(_canvasService.Get(CanvasType.MainMenu).transform);
            
            ChangeState(GameState.Menu);
        }

        public override void Exit()
        {
        }
    }
}