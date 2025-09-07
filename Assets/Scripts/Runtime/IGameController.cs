using System;
using Cysharp.Threading.Tasks;
using Snake.Core;
using UnityEngine;
using Zenject;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public interface IGameController
    {
        event Action<StepResult> OnStepUpdated;
        event Action<GameResult> OnStateChanged;
        void Initialize();
    }
    
    public class GameController : IGameController,IDisposable
    {
        public event Action<StepResult> OnStepUpdated;
        public event Action<GameResult> OnStateChanged;
        
        private readonly ISnakeModel _snakeModel;
        private readonly ISnakeCollisionService _collisionService;
        private readonly ISnakeFoodCollector _snakeFoodCollector;
        private readonly ISnakeMovementService _snakeMovementService;
        private readonly IFoodService _foodService;
        private readonly IInputProvider _inputProvider;
        
        private static float Speed = 0.5f;
        
        private bool _isGameRunning;
        
        public GameController(
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

        public void Initialize()
        {
            _inputProvider.OnInputDirectionChanged += OnInputDirectionChanged;

            _isGameRunning = true;
            
            _foodService.PlaceFood();
            
            OnStepUpdated?.Invoke(StepResult.Initialize);
            
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
            StepResult stepResult = StepResult.None;
            
            _snakeMovementService.Move();

            if (_collisionService.IsCollided())
            {
                OnStateChanged?.Invoke(GameResult.GameOver);
                _isGameRunning = false;
                stepResult = StepResult.Collided;
            }
            
            if (_foodService.CanCollectFood(_snakeModel.Head, out var foodModel))
            {
                _snakeFoodCollector.CollectFood(foodModel);
                _foodService.PlaceFood();
                stepResult = StepResult.FoodEaten;
            }
            
            Debug.Log($"Step completed with result {stepResult}");
            OnStepUpdated?.Invoke(stepResult);
        }

        private void OnInputDirectionChanged(Vector2Int direction)
        {
            _snakeMovementService.SetDirection(direction);
        }

        public void Dispose()
        {
            _inputProvider.OnInputDirectionChanged -= OnInputDirectionChanged;
        }
    }
    
    public enum GameResult
    {
        Playing,
        GameOver
    }

    public enum StepResult
    {
        None,
        Initialize,
        FoodEaten,
        Collided
    }
}