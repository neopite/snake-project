using Zenject;

namespace Snake
{
    public class PlayState : BaseState<GameState>
    {
        private readonly SignalBus _signalBus;

        public PlayState(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public override void OnEnter()
        {
            _signalBus.Subscribe<GameOverSignal>(OnGameOver);
            
            _signalBus.Fire<StartGameControllerSignal>();
        }

        private void OnGameOver(GameOverSignal obj)
        {
            ChangeState(GameState.Exit);
        }

        public override void OnExit()
        {
            _signalBus.Unsubscribe<GameOverSignal>(OnGameOver);
        }
    }
}