using Snake.Skinning;
using UnityEngine;
using Zenject;

namespace Snake
{
    public interface ISnakePartsProvider : ISkinnable
    {
        SnakePartView GetHead();
        SnakePartView GetTail();
        SnakePartView GetBody();
    }
    
    public class SnakePartProvider : ISnakePartsProvider, IInitializable
    {
        private SnakePartView _snakeBody;
        public void Initialize()
        {
            _snakeBody = Resources.Load<SnakePartView>("SnakePart");
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