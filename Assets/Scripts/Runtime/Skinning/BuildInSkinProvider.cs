using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Snake.Skinning
{
    public class BuildInSkinProvider : ISkinProvider
    {
        public async UniTask<GameSkin> Get()
        {
            var root = "BuildIn/Sprites/";

            var snakeBody = await Resources.LoadAsync<Sprite>(root + "SnakeBody").ToUniTask();
            var food = await Resources.LoadAsync<Sprite>(root + "Grid").ToUniTask();
            var background = await Resources.LoadAsync<Sprite>(root + "Food").ToUniTask();
            var snakeHead = await Resources.LoadAsync<Sprite>(root + "SnakeHead").ToUniTask();
            var snakeCorner = await Resources.LoadAsync<Sprite>(root + "SnakeBodyCorner").ToUniTask();
            
            var snakeBodySprite = snakeBody as Sprite;
            var foodSprite = food as Sprite;
            var backgroundSprite = background as Sprite;
            var snakeHeadSprite = snakeHead as Sprite;
            var snakeCornerSprite = snakeCorner as Sprite;
            
            return new GameSkin(backgroundSprite, foodSprite, snakeHeadSprite, snakeBodySprite, snakeCornerSprite);
        }
    }
}