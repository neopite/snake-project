using System.Collections.Generic;
using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public class SnakeView : MonoBehaviour
    {
        private List<SnakePartView> _snakeParts;
        
        private SnakePartView _snakeBodyTemplate;
        private SnakePartView _snakeHeadTemplate;
        
        private int _partsToGrow;

        public void InitializeSnakeView(SnakePartView snakeHeadTemplate, SnakePartView snakeBodyTemplate)
        {
            _snakeHeadTemplate = snakeHeadTemplate;
            _snakeBodyTemplate = snakeBodyTemplate;
            
            var part = Instantiate(_snakeHeadTemplate, Vector3.zero, Quaternion.identity);
            _snakeParts = new List<SnakePartView> { part };
        }

        public void Grow()
        {
            _partsToGrow++;
        }
        
        public void MoveSnake(Vector2Int moveDirection)
        {
            var direction = new Vector3(moveDirection.X, moveDirection.Y, 0);

            ReplaceHeadWithBody();
            SpawnHead(direction);
            RemoveTail();
        }

        private void ReplaceHeadWithBody()
        {
            if (_snakeParts.Count == 0)
            {
                return;
            }

            var oldHead = _snakeParts[0];
            var body = Instantiate(_snakeBodyTemplate, oldHead.transform.position, Quaternion.identity, transform);

            Destroy(oldHead.gameObject);
            _snakeParts[0] = body;
        }

        private void SpawnHead(Vector3 moveDirection)
        {
            var currentHeadPos = _snakeParts[0].transform.position;
            var newHeadPos = currentHeadPos + moveDirection;

            var newHead = Instantiate(_snakeHeadTemplate, newHeadPos, Quaternion.identity, transform);
            _snakeParts.Insert(0, newHead);
        }
        private void RemoveTail()
        {
            if (_partsToGrow > 0)
            {
                _partsToGrow--;   
                return;         
            }
            
            var tail = _snakeParts[^1];
            _snakeParts.RemoveAt(_snakeParts.Count - 1);
            
            Destroy(tail.gameObject);
        }
    }
}