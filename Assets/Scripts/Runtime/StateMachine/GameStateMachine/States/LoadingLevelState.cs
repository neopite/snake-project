using Cysharp.Threading.Tasks;
using Snake.Skinning;
using Snake.Window;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class LoadingLevelState : BaseState<GameState>
    {
        private const string GameSceneName = "GameScene";
        private const string StartScene = "StartScene";
        
        private readonly ISkinService _skinService;
        
        private readonly IFoodViewProvider _foodViewProvider;
        private readonly IGameViewRootProvider _gameViewRootProvider;
        private readonly ISnakeAssetsProvider _snakeAssetsProvider;
        private readonly IWindowService _windowService;
        private readonly ICanvasService _canvasService;
        private readonly ISceneService _sceneService;

        public LoadingLevelState(
            ISkinService skinService,
            IWindowService windowService,
            IFoodViewProvider foodViewProvider,
            IGameViewRootProvider gameViewRootProvider,
            ISnakeAssetsProvider snakeAssetsProvider,
            ICanvasService canvasService,
            ISceneService sceneService)
        {
            _skinService = skinService;
            _windowService = windowService;
            _foodViewProvider = foodViewProvider;
            _gameViewRootProvider = gameViewRootProvider;
            _snakeAssetsProvider = snakeAssetsProvider;
            _canvasService = canvasService;
            _sceneService = sceneService;
        }

        public async override void OnEnter()
        {
            await _foodViewProvider.Load();
            await _gameViewRootProvider.Load();
            await _snakeAssetsProvider.Load();

            await _sceneService.LoadGameSceneAsync();
            
            var gameSkin = await _skinService.GetSkin();
            
            _skinService.ApplySkin(gameSkin);

            ChangeState(GameState.Play);
        }

        public override void OnExit()
        {
        }
    }
}