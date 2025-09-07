using Cysharp.Threading.Tasks;
using Snake.Providers;
using Snake.Skinning;
using UnityEngine;
using Zenject;

namespace Snake
{
    public interface ISnakePartsProvider : ISkinnable, IAssetProvider
    {
        SnakePartView GetHead();
        SnakePartView GetTail();
        SnakePartView GetBody();
    }
    
    public class SnakePartProvider : ISnakePartsProvider
    {
        private SnakePartView _snakeBody;

        public async UniTask Load()
        {
            var snakePartObject = await Resources.LoadAsync<SnakePartView>("SnakePart").ToUniTask();
            
            _snakeBody = snakePartObject as SnakePartView;
        }

        public SnakePartView GetHead()
        {
            throw new System.NotImplementedException();
        }

        public SnakePartView GetTail()
        {
            throw new System.NotImplementedException();
        }

        public SnakePartView GetBody()
        {
            return _snakeBody;
        }

        public void ApplySkin(GameSkin skin)
        {
            _snakeBody.SetSprite(skin.Snake);
        }
    }
}