using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SnakeView
{
    public class BuildInSkinProvider : ISkinProvider
    {
        public SkinProviderType Type => SkinProviderType.BuildIn;
        
        private static readonly string Root = "{0}/Sprites/";
        
        public async UniTask<GameSkin> Get(string skinName)
        {
            var snakeBody = await LoadSprite(skinName,AssetNames.SnakeBody);
            var food = await LoadSprite( skinName,AssetNames.Food);
            var background = await LoadSprite(skinName,AssetNames.Background);
            var snakeHead = await LoadSprite(skinName,AssetNames.SnakeHead);
            var snakeCorner = await LoadSprite( skinName,AssetNames.SnakeBodyCorner);
            
            return new GameSkin(background, food, snakeHead, snakeBody, snakeCorner);
        }

        public bool CanProvide(string skinName)
        {
            if (string.IsNullOrEmpty(skinName))
            {
                return false;
            }
            
            var fullPath = Path.Combine(Application.dataPath, $"Resources/{skinName}");
            return Directory.Exists(fullPath);

        }

        private async UniTask<Sprite> LoadSprite(string skinName, string assetName)
        {
            var path = string.Format(Root, skinName) + assetName;
            var handle = await Resources.LoadAsync<Sprite>(path).ToUniTask();
            return handle as Sprite;
        }
    }
}