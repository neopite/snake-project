using System.Collections.Generic;
using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public class SnakeView : MonoBehaviour
    {
        private List<SnakePartView> _snakeParts;
        
        private SnakePartView _snakePartView;
        private int _partsToGrow = 0;

        public void InitializeSnakeView(SnakePartView snakePartViewTemplate)
        {
            _snakePartView = snakePartViewTemplate;
            
            var part = Instantiate(_snakePartView, Vector3.zero, Quaternion.identity);
            _snakeParts = new List<SnakePartView> { part };
        }

        public void Grow()
        {
            _partsToGrow++;
        }
        
        public void MoveSnake(Vector2Int moveDirection)
        {
            var direction = new Vector3(moveDirection.X, moveDirection.Y, 0);
            SpawnPart(direction);
            RemoveTail();
        }

        private void SpawnPart(Vector3 moveDirection)
        {
            var head = _snakeParts[0].transform.position;
            var newPosition = head + moveDirection;
            var part = Instantiate(_snakePartView, newPosition, Quaternion.identity);
            _snakeParts.Insert(0, part);
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