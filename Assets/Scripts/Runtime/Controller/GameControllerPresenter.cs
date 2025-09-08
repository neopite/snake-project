using System;
using Snake.Core;
using Zenject;
using Object = UnityEngine.Object;

namespace Snake
{
    public class GameControllerPresenter : IGameControllerPresenter, IInitializable, IDisposable
    {
        private readonly ISnakeModel _snakeModel;
        private readonly IGridModel _gridModel;
        private readonly IGameViewRootProvider _gameViewRootProvider;
        private readonly IGameController _gameController;
        private readonly SignalBus _signalBus;
        private readonly IFoodViewProvider _foodViewProvider; 
        private readonly IFoodService _foodService;
        private readonly ISnakePartsProvider _snakePartsProvider;
        
        private GameFacadeView _view;

        public GameControllerPresenter(
            ISnakeModel snakeModel,
            IGameViewRootProvider gameViewRootProvider,
            IGameController gameController,
            SignalBus signalBus,
            IGridModel gridModel,
            IFoodViewProvider foodViewProvider, 
            IFoodService foodService,
            ISnakePartsProvider snakePartsProvider)
        {
            _snakeModel = snakeModel;
            _gameViewRootProvider = gameViewRootProvider;
            _gameController = gameController;
            _signalBus = signalBus;
            _gridModel = gridModel;
            _foodViewProvider = foodViewProvider;
            _foodService = foodService;
            _snakePartsProvider = snakePartsProvider;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<LaunchGameControllerSignal>(Start);
        }

        private void Start()
        {
            _gameController.OnGameLoopStepCompleted += OnModelStepCompleted;
            _gameController.OnControllerStateChanged += OnGameStateChanged;
            
            _gameController.InitializeGrid();
            InitializeGridView();

            _gameController.LaunchLoop();
        }

        private void InitializeGridView()
        {
            var gameTemplate = _gameViewRootProvider.Get();
            var gameView = Object.Instantiate(gameTemplate);
            _view = gameView;
            _view.SetGridSize(_gridModel.Width, _gridModel.Height);

            var snakeBodyTemplate = _snakePartsProvider.GetBody();
            var snakeHeadTemplate = _snakePartsProvider.GetHead();
            
            _view.SetSnakeBodyTemplate(snakeHeadTemplate, snakeBodyTemplate);

            var newPos = _foodService.CurrentFoodPosition;
            var foodView = _foodViewProvider.SpawnFood(newPos);
            _view.SetFood(foodView);
        }

        private void OnGameStateChanged(ControllerState obj)
        {
            if (obj == ControllerState.GameOver)
            {
                _signalBus.Fire<GameOverSignal>();
            }
        }

        private void OnModelStepCompleted(StepResult result)
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
                var foodView = _foodViewProvider.SpawnFood(newPos);
                _view.SetFood(foodView);
            }
        }

        public void Dispose()
        {
            _gameController.OnGameLoopStepCompleted -= OnModelStepCompleted;
            _gameController.OnControllerStateChanged -= OnGameStateChanged;
            
            _signalBus.Unsubscribe<LaunchGameControllerSignal>(Start);
        }
    }
}