using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Snake.Skinning
{
    public class AssetBundleSkinProvider : ISkinProvider
    {
        private readonly string _assetBundlePath = Application.streamingAssetsPath + "/skin1";
        
        private GameSkin _skin;


        public async UniTask<GameSkin> Get()
        {
            if (_skin != null)
            {
                return _skin;
            }

            var bundle = await AssetBundle.LoadFromFileAsync(_assetBundlePath);
            if (bundle == null)
            {
                Debug.LogError("Failed to load AssetBundle!");
                return null;
            }
            
            var head = await bundle.LoadAssetAsync<Sprite>("Snake").ToUniTask();
            var food = await bundle.LoadAssetAsync<Sprite>("Food").ToUniTask();
            var background = await bundle.LoadAssetAsync<Sprite>("Grid").ToUniTask();
            
            var headSprite = head as Sprite;
            var foodSprite = food as Sprite;
            var backgroundSprite = background as Sprite;
                
            return new GameSkin(backgroundSprite, foodSprite, headSprite);
        }
    }
}