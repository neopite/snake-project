using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public class FoodView : MonoBehaviour
    {
        public void SetPosition(Vector2Int position)
        {
            transform.position = new Vector3(position.X, position.Y, 0);
        }
    }
}