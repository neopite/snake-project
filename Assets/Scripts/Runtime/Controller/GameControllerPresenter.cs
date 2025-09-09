using System;
using Snake.Core;
using Zenject;
using Object = UnityEngine.Object;
using Vector2Int = UnityEngine.Vector2Int;

namespace SnakeView
{
    public class GameControllerPresenter : IGameControllerPresenter, IInitializable, IDisposable
    {
        private readonly ISnakeModel _snakeModel;
        private readonly IGridModel _gridModel;
        private readonly IGameViewRootProvider _gameViewRootProvider;
        private readonly IGameLoopControllerWrapper _gameLoopControllerWrapper;
        private readonly SignalBus _signalBus;
        private readonly IFoodViewProvider _foodViewProvider; 
        private readonly IFoodService _foodService;
        private readonly ISnakeAssetsProvider _snakeAssetsProvider;
        private readonly IGameLoopControllerEvents _gameLoopControllerEvents;
        
        private GameFacadeView _view;

        public GameControllerPresenter(
            ISnakeModel snakeModel,
            IGameViewRootProvider gameViewRootProvider,
            IGameLoopControllerWrapper gameLoopControllerWrapper,
            SignalBus signalBus,
            IGridModel gridModel,
            IFoodViewProvider foodViewProvider, 
            IFoodService foodService,
            ISnakeAssetsProvider snakeAssetsProvider,
            IGameLoopControllerEvents gameLoopControllerEvents)
        {
            _snakeModel = snakeModel;
            _gameViewRootProvider = gameViewRootProvider;
            _gameLoopControllerWrapper = gameLoopControllerWrapper;
            _signalBus = signalBus;
            _gridModel = gridModel;
            _foodViewProvider = foodViewProvider;
            _foodService = foodService;
            _snakeAssetsProvider = snakeAssetsProvider;
            _gameLoopControllerEvents = gameLoopControllerEvents;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<LaunchGameControllerSignal>(Start);
        }

        private void Start()
        {
            _gameLoopControllerEvents.OnGameLoopStepCompleted += OnModelStepCompleted;
            _gameLoopControllerEvents.OnControllerStateChanged += OnGameStateChanged;
            
            _gameLoopControllerWrapper.InitializeGrid();
            InitializeGridView();

            _gameLoopControllerWrapper.LaunchLoop();
        }

        private void InitializeGridView()
        {
            var gameTemplate = _gameViewRootProvider.Get();
            var gameView = Object.Instantiate(gameTemplate);
            _view = gameView;
            _view.SetGridSize(_gridModel.Width, _gridModel.Height);

            var body = _snakeAssetsProvider.GetBody();
            var corner = _snakeAssetsProvider.GetBodyCorner();
            var head = _snakeAssetsProvider.GetHead();
            
            _view.SetSnakeBodyTemplate(body, corner, head);

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

            var direction = _snakeModel.Direction;
            _view.MoveSnake(new Vector2Int(direction.X, direction.Y));

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
            _gameLoopControllerEvents.OnGameLoopStepCompleted -= OnModelStepCompleted;
            _gameLoopControllerEvents.OnControllerStateChanged -= OnGameStateChanged;
            
            _signalBus.Unsubscribe<LaunchGameControllerSignal>(Start);
        }
    }
}