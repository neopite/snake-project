using System;

namespace Snake.Core
{
    public interface IGameLoopController : IGameLoopControllerEvents
    {
        StepResult Result { get; } 
        void Step();
    }

    public interface IGameLoopControllerEvents
    {
        event Action<StepResult> OnGameLoopStepCompleted;
        event Action<ControllerState> OnControllerStateChanged;
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