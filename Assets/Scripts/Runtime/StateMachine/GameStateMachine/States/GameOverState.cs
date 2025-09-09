using UnityEngine;
using Zenject;

namespace SnakeView
{
    public class GameOverState : BaseState<GameState>
    {
        private readonly IWindowService _windowService;
        private readonly SignalBus _signalBus;

        public GameOverState(IWindowService windowService, SignalBus signalBus)
        {
            _windowService = windowService;
            _signalBus = signalBus;
        }

        public override void Enter()
        {
            _windowService.Add(WindowName.GameOver);
            
            _signalBus.Subscribe<PlayAgainSignal>(OnPlayAgainPressed);
        }

        private void OnPlayAgainPressed()
        {
            _windowService.RemoveCurrent();
            
            ChangeState(GameState.Reload);
        }

        public override void Exit()
        {
            _signalBus.Unsubscribe<PlayAgainSignal>(OnPlayAgainPressed);
        }
    }
}