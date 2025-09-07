using UnityEngine;

namespace Snake
{
    public class SnakeView : MonoBehaviour
    {
        public void SetInitialPosition(int x, int y)
        {
            gameObject.transform.position = new Vector3(x, y, 0);
        }
    }
}