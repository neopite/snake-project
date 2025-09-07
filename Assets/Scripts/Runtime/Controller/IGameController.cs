using System;

namespace Snake
{
    public interface IGameController
    {
        event Action<StepResult> OnGameLoopStepCompleted;
        event Action<ControllerState> OnControllerStateChanged;
        void InitializeGrid();
        void LaunchLoop();
    }

    public enum ControllerState
    {
        Playing,
        GameOver
    }

    public enum StepResult
    {
        None,
        FoodEaten,
        Collided
    }
}