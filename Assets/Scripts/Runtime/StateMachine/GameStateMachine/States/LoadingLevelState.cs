using Snake;
using SnakeView.Config;

namespace SnakeView
{
    public class LoadingLevelState : BaseState<GameState>
    {
        private readonly ISkinService _skinService;
        
        private readonly IFoodViewProvider _foodViewProvider;
        private readonly IGameViewRootProvider _gameViewRootProvider;
        private readonly ISnakeAssetsProvider _snakeAssetsProvider;
        private readonly ISceneService _sceneService;
        private readonly GameSkinConfig _config;

        public LoadingLevelState(
            ISkinService skinService,
            IFoodViewProvider foodViewProvider,
            IGameViewRootProvider gameViewRootProvider,
            ISnakeAssetsProvider snakeAssetsProvider,
            ISceneService sceneService, 
            GameSkinConfig config)
        {
            _skinService = skinService;
            _foodViewProvider = foodViewProvider;
            _gameViewRootProvider = gameViewRootProvider;
            _snakeAssetsProvider = snakeAssetsProvider;
            _sceneService = sceneService;
            _config = config;
        }

        public async override void Enter()
        {
            await _foodViewProvider.Load();
            await _gameViewRootProvider.Load();
            await _snakeAssetsProvider.Load();

            await _sceneService.LoadGameSceneAsync();
            
            var gameSkin = await _skinService.GetSkin(_config.SkinName);
            
            _skinService.ApplySkin(gameSkin);

            ChangeState(GameState.Play);
        }

        public override void Exit()
        {
        }
    }
}