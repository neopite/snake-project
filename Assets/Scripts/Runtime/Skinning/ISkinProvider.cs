using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SnakeView
{
    public interface ISkinProvider
    {
        SkinProviderType Type { get; }
        UniTask<GameSkin> Get(GameSkinType skinType);
        bool CanProvide(GameSkinType skinType);
    }

    public enum SkinProviderType
    {
        BuildIn,
        Remote
    }

    public class GameSkin
    {
        public Sprite Background { get; }
        public Sprite Food { get; }
        public Sprite SnakeHead { get; }
        public Sprite SnakeBody { get; }
        public Sprite SnakeBodyCorner { get; }

        public GameSkin(Sprite background,
            Sprite food,
            Sprite snakeHead,
            Sprite snakeBody,
            Sprite snakeBodyCorner)
        {
            Background = background;
            Food = food;
            SnakeHead = snakeHead;
            SnakeBody = snakeBody;
            SnakeBodyCorner = snakeBodyCorner;
        }
    }
}