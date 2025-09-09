using System.Collections.Generic;
using UnityEngine;

namespace SnakeView
{
    public class SnakeView : MonoBehaviour
    {
        [SerializeField]
        private SnakePartView _snakeBodyTemplate;
        private Sprite _snakeBodySprite;
        private Sprite _snakeHeadSprite;
        private Sprite _snakeCornerSprite;

        private List<SnakePartView> _snakeParts;
        
        private int _partsToGrow;

        public void InitializeSnakeView(Sprite snakeBody, Sprite snakeCorner, Sprite snakeHead)
        {
            _snakeBodySprite = snakeBody;
            _snakeHeadSprite = snakeHead;
            _snakeCornerSprite = snakeCorner;
            
            var part = Instantiate(_snakeBodyTemplate, Vector3.zero, Quaternion.identity);
            part.SetSprite(_snakeHeadSprite);
            _snakeParts = new List<SnakePartView> { part };
        }

        public void Grow()
        {
            _partsToGrow++;
        }
        
        public void MoveSnake(Vector2Int moveDirection)
        {
            var direction = new Vector3(moveDirection.x, moveDirection.y, 0);

            ReplaceHeadWithBody();
            SpawnHead(direction);
            RotateHead(_snakeParts[0], moveDirection);
            UpdateBodySprites();
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

            var newHead = Instantiate(_snakeBodyTemplate, newHeadPos, Quaternion.identity, transform);
            newHead.SetSprite(_snakeHeadSprite);
            _snakeParts.Insert(0, newHead);
        }
        
        private void RotateHead(SnakePartView head, Vector2Int direction)
        {
            if (direction.x == 1)
            {
                head.transform.rotation = Quaternion.Euler(0, 0, 0);
            } 
            else if (direction.x == -1)
            {
                head.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (direction.y == 1)
            {
                head.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (direction.y == -1)
            {
                head.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }

        private void UpdateBodySprites()
        {
            for (int i = 1; i < _snakeParts.Count - 1; i++)
            {
                var currPos = Vector2Int.RoundToInt(_snakeParts[i].transform.position);
                var prevPos = Vector2Int.RoundToInt(_snakeParts[i - 1].transform.position);
                var nextPos = Vector2Int.RoundToInt(_snakeParts[i + 1].transform.position);

                var dirToPrev = prevPos - currPos;
                var dirToNext = nextPos - currPos;

                var snakePart = _snakeParts[i];

                if (dirToPrev.x != 0 && dirToNext.x != 0)
                {
                    SetSprite(snakePart, _snakeBodySprite, 0);
                }
                else if (dirToPrev.y != 0 && dirToNext.y != 0)
                {
                    SetSprite(snakePart, _snakeBodySprite, 90);
                }
                else
                {
                    SetSprite(snakePart, _snakeCornerSprite, GetCornerRotation(dirToPrev, dirToNext));
                }
            }
        }

        private void SetSprite(SnakePartView partView, Sprite sprite, float rotationZ)
        {
            partView.SetSprite(sprite);
            partView.SetPartRotation(rotationZ);
        }

        private float GetCornerRotation(Vector2Int dirToPrev, Vector2Int dirToNext)
        {
            int x = dirToPrev.x != 0 ? dirToPrev.x : dirToNext.x;
            int y = dirToPrev.y != 0 ? dirToPrev.y : dirToNext.y;

            if (x == -1 && y == 1)
            {
                return 270;
            }
            if (x == 1 && y == 1)
            {
                return 180;
            }
            if (x == -1 && y == -1)
            {
                return 0;
            }
            if (x == 1 && y == -1)
            {
                return 90;
            }

            return 0;
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