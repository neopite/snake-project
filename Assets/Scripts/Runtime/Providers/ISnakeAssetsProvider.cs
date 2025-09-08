using Cysharp.Threading.Tasks;
using Snake.Providers;
using Snake.Skinning;
using UnityEngine;
using Zenject;

namespace Snake
{
    public interface ISnakeAssetsProvider : ISkinnable, IAssetProvider
    {
        SnakePartView GetSnakePrefab();
        Sprite GetBody();
        Sprite GetBodyCorner();
        Sprite GetHead();
    }
    
    public class SnakeAssetProvider : ISnakeAssetsProvider
    {
        private SnakePartView _snakePartPrefab;
        private Sprite _snakeHead;
        private Sprite _snakeBody;
        private Sprite _snakeBodyCorner;

        public async UniTask Load()
        {
            var snakeBodyObject = await Resources.LoadAsync<SnakePartView>("SnakeBody").ToUniTask();
            
            _snakePartPrefab = snakeBodyObject as SnakePartView;
        }

        public SnakePartView GetSnakePrefab()
        {
            return _snakePartPrefab;
        }

        public Sprite GetBody()
        {
            return _snakeBody;
        }
        
        public Sprite GetHead()
        {
            return _snakeHead;
        }

        public Sprite GetBodyCorner()
        {
            return _snakeBodyCorner;
        }

        public void ApplySkin(GameSkin skin)
        {
            _snakeBody = skin.SnakeBody;
            _snakeHead = skin.SnakeHead;
            _snakeBodyCorner = skin.SnakeBodyCorner;
        }
    }
}