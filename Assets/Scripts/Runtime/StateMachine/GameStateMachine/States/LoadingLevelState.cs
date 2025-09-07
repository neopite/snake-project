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
        private readonly ISnakePartsProvider _snakePartsProvider;
        private readonly IWindowService _windowService;
        private readonly ICanvasService _canvasService;

        public LoadingLevelState(
            ISkinService skinService,
            IWindowService windowService,
            IFoodViewProvider foodViewProvider,
            IGameViewRootProvider gameViewRootProvider,
            ISnakePartsProvider snakePartsProvider, ICanvasService canvasService)
        {
            _skinService = skinService;
            _windowService = windowService;
            _foodViewProvider = foodViewProvider;
            _gameViewRootProvider = gameViewRootProvider;
            _snakePartsProvider = snakePartsProvider;
            _canvasService = canvasService;
        }

        public async override void OnEnter()
        {
            await _foodViewProvider.Load();
            await _gameViewRootProvider.Load();
            await _snakePartsProvider.Load();
            
            await SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Additive);
            await SceneManager.UnloadSceneAsync(StartScene);
            
            _windowService.SetRoot(_canvasService.Get(CanvasType.Game).transform);

            var gameSkin = await _skinService.GetSkin();
            
            _skinService.ApplySkin(gameSkin);

            ChangeState(GameState.Play);
        }

        public override void OnExit()
        {
        }
    }
}