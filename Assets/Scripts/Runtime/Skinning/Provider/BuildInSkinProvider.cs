using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SnakeView
{
    public class BuildInSkinProvider : ISkinProvider
    {
        public SkinProviderType Type => SkinProviderType.BuildIn;
        
        private static readonly string Root = "BuildIn/Sprites/";
        
        public async UniTask<GameSkin> Get(GameSkinType skinType)
        {
            var snakeBody = await LoadSprite(AssetNames.SnakeBody);
            var food = await LoadSprite( AssetNames.Food);
            var background = await LoadSprite(AssetNames.Background);
            var snakeHead = await LoadSprite(AssetNames.SnakeHead);
            var snakeCorner = await LoadSprite( AssetNames.SnakeBodyCorner);
            
            return new GameSkin(background, food, snakeHead, snakeBody, snakeCorner);
        }

        public bool CanProvide(GameSkinType skinType)
        {
            return skinType == GameSkinType.BuildIn;
        }

        private async UniTask<Sprite> LoadSprite(string assetName)
        {
            var handle = await Resources.LoadAsync<Sprite>(Root + assetName).ToUniTask();
            return handle as Sprite;
        }
    }
}