using Zenject;

namespace Snake
{
    public interface IGameStateMachineFactory
    {
        GameStateMachine Create();
    }
    
    public class GameStateMachineFactory : IGameStateMachineFactory
    {
        private readonly DiContainer _diContainer;

        public GameStateMachineFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameStateMachine Create()
        {
            var stateRegister = new StateRegister<GameState>(_diContainer);
            
            stateRegister.Add<LaunchState>(GameState.Launch);
            stateRegister.Add<MenuState>(GameState.Menu);
            stateRegister.Add<LoadingLevelState>(GameState.LoadingLevel);
            stateRegister.Add<PlayState>(GameState.Play);
            stateRegister.Add<GameOverState>(GameState.GameOver);
            stateRegister.Add<ReloadState>(GameState.Reload);
            stateRegister.Add<ExitState>(GameState.Exit);

            var machine = new GameStateMachine();
            
            machine.SetRegister(stateRegister);

            return machine;
        }
    }
}