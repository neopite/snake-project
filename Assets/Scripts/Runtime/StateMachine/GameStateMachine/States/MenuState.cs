using UnityEngine;
using Zenject;

namespace SnakeView
{
    public class MenuState : BaseState<GameState>
    {
        private readonly IWindowService _windowService;
        private readonly SignalBus _signalBus;

        public MenuState(IWindowService windowService, SignalBus signalBus)
        {
            _windowService = windowService;
            _signalBus = signalBus;
        }
        
        public override void Enter()
        {
            _windowService.Add(WindowName.MainMenu);
            
            _signalBus.Subscribe<LoadLevelSignal>(OnLoadLevel);
            _signalBus.Subscribe<ExitApplicationSignal>(OnExitApplication);
        }

        private void OnLoadLevel()
        {
            ChangeState(GameState.LoadingLevel);
        }

        private void OnExitApplication()
        {
            ChangeState(GameState.Exit);
        }

        public override void Exit()
        {
            _signalBus.Unsubscribe<LoadLevelSignal>(OnLoadLevel);
            _signalBus.Unsubscribe<ExitApplicationSignal>(OnExitApplication);
        }
    }
}