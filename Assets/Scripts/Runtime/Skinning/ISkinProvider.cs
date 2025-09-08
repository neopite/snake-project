using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Snake.Skinning
{
    public interface ISkinProvider
    {
        UniTask<GameSkin> Get();
    }

    public class GameSkin
    {
        public Sprite Background { get; }
        public Sprite Food { get; }
        public Sprite SnakeHead { get; }
        public Sprite SnakeBody { get; }

        public GameSkin(Sprite background, Sprite food, Sprite snakeHead, Sprite snakeBody)
        {
            Background = background;
            Food = food;
            SnakeHead = snakeHead;
            SnakeBody = snakeBody;
        }
    }
}