using System;
using Snake.Core;
using Zenject;
using Object = UnityEngine.Object;

namespace Snake
{
    public interface IGameControllerPresenter
    {
    }
    
    public class GameControllerPresenter : IGameControllerPresenter, IInitializable, IDisposable
    {
        private readonly ISnakeModel _snakeModel;
        private readonly IGridModel _gridModel;
        private readonly IGameViewRootProvider _gameViewRootProvider;
        private readonly IGameController _gameController;
        private readonly SignalBus _signalBus;
        private readonly IFoodViewSpawner _foodViewSpawner; 
        private readonly IFoodService _foodService;
        
        private GameFacadeView _view;

        public GameControllerPresenter(
            ISnakeModel snakeModel,
            IGameViewRootProvider gameViewRootProvider,
            IGameController gameController,
            SignalBus signalBus,
            IGridModel gridModel,
            IFoodViewSpawner foodViewSpawner, 
            IFoodService foodService)
        {
            _snakeModel = snakeModel;
            _gameViewRootProvider = gameViewRootProvider;
            _gameController = gameController;
            _signalBus = signalBus;
            _gridModel = gridModel;
            _foodViewSpawner = foodViewSpawner;
            _foodService = foodService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<StartGameControllerSignal>(Start);
        }


        public void Start()
        {
            var gameTemplate = _gameViewRootProvider.Get();
            var gameView = Object.Instantiate(gameTemplate);
            _view = gameView;
            
            _view.SetGridSize(_gridModel.Width, _gridModel.Height);
            _gameController.OnStepUpdated += OnModelUpdated;
            _gameController.OnStateChanged += OnGameStateChanged;
            
            _gameController.Initialize();
        }

        private void OnGameStateChanged(GameResult obj)
        {
            if (obj == GameResult.GameOver)
            {
                _signalBus.Fire<GameOverSignal>();
            }
        }

        private void OnModelUpdated(StepResult result)
        {
            if (result == StepResult.Collided)
            {
                return;
            }
            
            _view.MoveSnake(_snakeModel.Direction);

            if (result == StepResult.FoodEaten)
            {
                _view.EatFood();

                var newPos = _foodService.CurrentFoodPosition;
                var foodView = _foodViewSpawner.SpawnFood(newPos);
                _view.SetFood(foodView);
            }

            
            //TODO remove it further. Extra and bad solution  
            if (result == StepResult.Initialize)
            {
                var newPos = _foodService.CurrentFoodPosition;
                var foodView = _foodViewSpawner.SpawnFood(newPos);
                _view.SetFood(foodView);
            }
        }

        public void Dispose()
        {
            _gameController.OnStepUpdated -= OnModelUpdated;
            
            _signalBus.Unsubscribe<StartGameControllerSignal>(Start);
        }
    }
}