using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public class GameFacadeView : MonoBehaviour
    {
        [SerializeField] 
        private SnakeView _snake;
        
        [SerializeField]
        private GridView _grid;

        public void MoveSnake(Vector2Int moveDirection)
        {
            _snake.UpdatePosition(moveDirection);
        }

        public void SetGridSize(int width, int height)
        {
            _grid.SetGridSize(width, height);
        }
    }
}