using System;
using Cysharp.Threading.Tasks;
using Snake.Core;
using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public class GameLoopController : IGameController,IDisposable
    {
        public event Action<StepResult> OnGameLoopStepCompleted;
        public event Action<ControllerState> OnControllerStateChanged;
        
        private readonly ISnakeModel _snakeModel;
        private readonly ISnakeCollisionService _collisionService;
        private readonly ISnakeFoodCollector _snakeFoodCollector;
        private readonly ISnakeMovementService _snakeMovementService;
        private readonly IFoodService _foodService;
        private readonly IInputProvider _inputProvider;
        private readonly IGridModel _gridModel;
        
        private static float Speed = 0.14f;
        
        private bool _isGameRunning;
        private bool _firstInputMade;
        
        public GameLoopController(
            ISnakeModel snakeModel,
            ISnakeCollisionService collisionService,
            ISnakeFoodCollector snakeFoodCollector,
            ISnakeMovementService snakeMovementService,
            IFoodService foodService,
            IInputProvider inputProvider)
        {
            _snakeModel = snakeModel;
            _collisionService = collisionService;
            _snakeFoodCollector = snakeFoodCollector;
            _snakeMovementService = snakeMovementService;
            _foodService = foodService;
            _inputProvider = inputProvider;
        }

        public void InitializeGrid()
        {
            _foodService.PlaceFood();
        }

        public void LaunchLoop()
        {
            _inputProvider.OnInputDirectionChanged += OnInputDirectionChanged;

            _isGameRunning = true;

            RunLoop().Forget();
        }

        private async UniTaskVoid RunLoop()
        {
            while (_isGameRunning)
            {
                Step();
                await UniTask.Delay(TimeSpan.FromSeconds(Speed));
            }
        }

        private void Step()
        {
            if (!_firstInputMade)
            {
                return;
            }
            
            StepResult step = StepResult.None;
            
            _snakeMovementService.Move();

            if (_collisionService.IsCollided())
            {
                OnControllerStateChanged?.Invoke(ControllerState.GameOver);
                _isGameRunning = false;
                step = StepResult.Collided;
            }
            
            if (_foodService.CanCollectFood(_snakeModel.Head, out var foodModel))
            {
                _snakeFoodCollector.CollectFood(foodModel);
                _foodService.PlaceFood();
                step = StepResult.FoodEaten;
            }
            
            Debug.Log($"Step completed with result {step}");
            OnGameLoopStepCompleted?.Invoke(step);
        }
        

        private void OnInputDirectionChanged(Vector2Int direction)
        {
            _firstInputMade = true;
            _snakeMovementService.SetDirection(direction);
        }

        public void Dispose()
        {
            _inputProvider.OnInputDirectionChanged -= OnInputDirectionChanged;
        }
    }
}