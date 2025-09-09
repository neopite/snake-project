using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SnakeView
{
    public class AssetBundleSkinProvider : ISkinProvider
    {
        public SkinProviderType Type => SkinProviderType.Remote;
        
        private readonly string _assetBundlePath = Application.streamingAssetsPath + "/";

        private GameSkin _skin;


        public async UniTask<GameSkin> Get(GameSkinType type)
        {
            if (_skin != null)
                return _skin;

            var bundle = await AssetBundle.LoadFromFileAsync(_assetBundlePath + type);
            if (bundle == null)
            {
                Debug.LogError("Failed to load AssetBundle");
                return null;
            }

            var background = await LoadSprite(bundle, AssetNames.Background);
            var food = await LoadSprite(bundle, AssetNames.Food);
            var head = await LoadSprite(bundle, AssetNames.SnakeHead);
            var body = await LoadSprite(bundle, AssetNames.SnakeBody);
            var corner = await LoadSprite(bundle, AssetNames.SnakeBodyCorner);

            _skin = new GameSkin(background, food, head, body, corner);
            return _skin;
        }

        public bool CanProvide(GameSkinType skinType)
        {
            return skinType != GameSkinType.BuildIn;
        }

        private async UniTask<Sprite> LoadSprite(AssetBundle bundle, string assetName)
        {
            var handle = await bundle.LoadAssetAsync<Sprite>(assetName).ToUniTask();
            return handle as Sprite;
        }
    }
}