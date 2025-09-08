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
        private SnakePartView _snakeHead;

        public async UniTask Load()
        {
            var snakeBodyObject = await Resources.LoadAsync<SnakePartView>("SnakeBody").ToUniTask();
            var snakeHeadObject = await Resources.LoadAsync<SnakePartView>("SnakeHead").ToUniTask();
            
            _snakeBody = snakeBodyObject as SnakePartView;
            _snakeHead = snakeHeadObject as SnakePartView;
        }

        public SnakePartView GetHead()
        {
            return _snakeHead;
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
            _snakeBody.SetSprite(skin.SnakeBody);
            _snakeHead.SetSprite(skin.SnakeHead);
        }
    }
}