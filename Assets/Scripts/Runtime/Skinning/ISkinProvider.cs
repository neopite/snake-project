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
        public Sprite Snake { get; }

        public GameSkin(Sprite background, Sprite food, Sprite snake)
        {
            Background = background;
            Food = food;
            Snake = snake;
        }
    }
}