using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Snake.Skinning
{
    public class BuildInSkinProvider : ISkinProvider
    {
        public async UniTask<GameSkin> Get()
        {
            var root = "BuildIn/Sprites/";

            var snake = await Resources.LoadAsync<Sprite>(root + "Snake").ToUniTask();
            var food = await Resources.LoadAsync<Sprite>(root + "Grid").ToUniTask();
            var background = await Resources.LoadAsync<Sprite>(root + "Food").ToUniTask();
            
            var snakeSprite = snake as Sprite;
            var foodSprite = food as Sprite;
            var backgroundSprite = background as Sprite;
            
            return new GameSkin(backgroundSprite, snakeSprite, foodSprite);
        }
    }
}