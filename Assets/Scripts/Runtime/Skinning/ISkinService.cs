using Cysharp.Threading.Tasks;

namespace Snake.Skinning
{
    public interface ISkinService
    {
        UniTask<GameSkin> GetSkin();
        void ApplySkin(GameSkin skin);
    }
    
    public class SkinService : ISkinService
    {
        private readonly IFoodViewProvider _foodViewProvider;
        private readonly IGameViewRootProvider _gameViewRootProvider;
        private readonly ISnakeAssetsProvider _snakeAssetsProvider;
        
        private readonly AssetBundleSkinProvider _buildInSkinProvider;
        
        private GameSkin _gameSkin;

        public SkinService(
            IFoodViewProvider foodViewProvider,
            IGameViewRootProvider gameViewRootProvider,
            ISnakeAssetsProvider snakeAssetsProvider, AssetBundleSkinProvider buildInSkinProvider)
        {
            _foodViewProvider = foodViewProvider;
            _gameViewRootProvider = gameViewRootProvider;
            _snakeAssetsProvider = snakeAssetsProvider;
            _buildInSkinProvider = buildInSkinProvider;
        }

        public async UniTask<GameSkin> GetSkin()
        {
            var gameSkin = await _buildInSkinProvider.Get();
            _gameSkin = gameSkin;
            return gameSkin;
        }

        public void ApplySkin(GameSkin skin)
        {
            _foodViewProvider.ApplySkin(skin);
            _gameViewRootProvider.ApplySkin(skin);
            _snakeAssetsProvider.ApplySkin(skin);
        }
    }
}