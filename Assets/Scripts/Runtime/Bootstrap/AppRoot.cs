using SnakeView.GameStateMachine;
using Zenject;

namespace SnakeView
{
    public class AppRoot : IInitializable
    {
        private readonly IGameStateMachineFactory _gameStateMachineFactory;

        public AppRoot(IGameStateMachineFactory gameStateMachineFactory)
        {
            _gameStateMachineFactory = gameStateMachineFactory;
        }

        public void Initialize()
        {
            var machine = _gameStateMachineFactory.Create();
            machine.Switch(GameState.Launch);
        }
    }
}