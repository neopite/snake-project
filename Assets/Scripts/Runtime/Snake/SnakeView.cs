using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public class SnakeView : MonoBehaviour
    {
        public void UpdatePosition(Vector2Int moveDirection)
        {
            transform.position += new Vector3(moveDirection.X, moveDirection.Y,0);
        }
    }
}