using SnakeView.Base;

namespace SnakeView.GameStateMachine
{
    public class GameStateMachine : BaseStateMachine<GameState>
    {
    }

    public enum GameState
    {
        Launch,
        Menu,
        LoadingLevel,
        Play,
        GameOver,
        Reload,
        Exit
    }
}