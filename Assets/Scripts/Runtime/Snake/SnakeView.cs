using System.Collections.Generic;
using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public class SnakeView : MonoBehaviour
    {
        private List<SnakePart> _snakeParts;
        
        [SerializeField]
        private GameObject _snakePartPrefab;

        [SerializeField]
        private GameObject _head;

        private int _growSegments = 0;

        public void Awake()
        {
            _snakeParts = new List<SnakePart>();
            _snakeParts.Add(new SnakePart(_head));
        }

        public void Grow()
        {
            _growSegments++;
        }
        
        public void MoveSnake(Vector2Int moveDirection)
        {
            var direction = new Vector3(moveDirection.X, moveDirection.Y, 0);
            SpawnPart(direction);
            RemoveTail();
        }

        private void SpawnPart(Vector3 moveDirection)
        {
            var head = _snakeParts[0].Part.transform.position;
            var newPosition = head + moveDirection;
            var part = Instantiate(_snakePartPrefab, newPosition, Quaternion.identity);
            _snakeParts.Insert(0, new SnakePart(part));
        }

        private void RemoveTail()
        {
            if (_growSegments > 0)
            {
                _growSegments--;   
                return;         
            }
            
            var tail = _snakeParts[^1];
            _snakeParts.RemoveAt(_snakeParts.Count - 1);
            
            Destroy(tail.Part);
        }
    }
}