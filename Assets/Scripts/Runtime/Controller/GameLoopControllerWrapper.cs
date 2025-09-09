using System;
using Cysharp.Threading.Tasks;
using Snake.Core;
using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace SnakeView
{
    public class GameLoopControllerWrapper : IGameLoopControllerWrapper,IDisposable
    {
        private readonly ISnakeMovementService _snakeMovementService;
        private readonly IFoodService _foodService;
        private readonly IInputProvider _inputProvider;
        private readonly IGridModel _gridModel;
        
        private readonly IGameLoopController _gameLoopController;
        
        private static float Speed = 0.1f;
        
        private bool _isGameRunning;
        private bool _firstInputMade;
        
        public GameLoopControllerWrapper(
            ISnakeMovementService snakeMovementService,
            IFoodService foodService,
            IInputProvider inputProvider,
            IGameLoopController gameLoopController)
        {
            _snakeMovementService = snakeMovementService;
            _foodService = foodService;
            _inputProvider = inputProvider;
            _gameLoopController = gameLoopController;
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
            
            _gameLoopController.Step();

            if (_gameLoopController.Result == StepResult.Collided)
            {
                _isGameRunning = false;
            }
            
            Debug.Log($"Step completed with result {_gameLoopController.Result}");
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