using System;

namespace Snake.Core
{
    public class GameLoopController : IGameLoopController
    {
        public StepResult Result { get; private set; }
        
        public event Action<StepResult> OnGameLoopStepCompleted;
        public event Action<ControllerState> OnControllerStateChanged;
        
        private readonly ISnakeMovementService _snakeMovementService;
        private readonly ISnakeCollisionService _collisionService;
        private readonly IFoodService _foodService;
        private readonly ISnakeModel _snakeModel;
        private readonly IScoreModel _scoreModel;

        public GameLoopController(
            ISnakeMovementService snakeMovementService,
            ISnakeCollisionService collisionService,
            IFoodService foodService,
            ISnakeModel snakeModel,
            IScoreModel scoreModel)
        {
            _snakeMovementService = snakeMovementService;
            _collisionService = collisionService;
            _foodService = foodService;
            _snakeModel = snakeModel;
            _scoreModel = scoreModel;
        }


        public void Step()
        {
            Result = StepResult.None;
            
            _snakeMovementService.Move();

            if (_collisionService.IsCollided())
            {
                OnControllerStateChanged?.Invoke(ControllerState.GameOver);
                Result = StepResult.Collided;
            }
            
            if (_foodService.CanCollectFood(_snakeModel.Head, out var foodModel))
            {
                _snakeModel.Grow();
                _scoreModel.Increase(foodModel.Points);
                _foodService.PlaceFood();
                Result = StepResult.FoodEaten;
            }
            
            OnGameLoopStepCompleted?.Invoke(Result);
        }
    }
}