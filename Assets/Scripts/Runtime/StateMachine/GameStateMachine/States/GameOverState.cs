using UnityEngine;
using Zenject;

namespace Snake
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

        public override void OnEnter()
        {
            _windowService.Add(WindowName.GameOver);
            
            _signalBus.Subscribe<ExitApplicationSignal>(OnApplicationExit);
            _signalBus.Subscribe<PlayAgainSignal>(OnPlayAgainPressed);
        }

        private void OnPlayAgainPressed()
        {
            ChangeState(GameState.Reload);
        }

        private void OnApplicationExit()
        {
            Application.Quit();
        }

        public override void OnExit()
        {
            _signalBus.Unsubscribe<ExitApplicationSignal>(OnApplicationExit);
            _signalBus.Unsubscribe<PlayAgainSignal>(OnPlayAgainPressed);
        }
    }
}