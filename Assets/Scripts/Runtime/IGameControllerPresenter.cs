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
        
        private GameFacadeView _view;

        public GameControllerPresenter(
            ISnakeModel snakeModel,
            IGameViewRootProvider gameViewRootProvider,
            IGameController gameController, SignalBus signalBus, IGridModel gridModel)
        {
            _snakeModel = snakeModel;
            _gameViewRootProvider = gameViewRootProvider;
            _gameController = gameController;
            _signalBus = signalBus;
            _gridModel = gridModel;
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
            _gameController.Initialize();
            _gameController.OnStepUpdated += OnModelUpdated;
            _gameController.OnStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameResult obj)
        {
            if (obj == GameResult.GameOver)
            {
                _signalBus.Fire<GameOverSignal>();
            }
        }

        private void OnModelUpdated()
        {
            _view.MoveSnake(_snakeModel.Direction);
        }

        public void Dispose()
        {
            _gameController.OnStepUpdated -= OnModelUpdated;
            
            _signalBus.Unsubscribe<StartGameControllerSignal>(Start);
        }
    }
}