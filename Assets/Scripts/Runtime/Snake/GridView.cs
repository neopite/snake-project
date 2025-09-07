using UnityEngine;

namespace Snake
{
    public class GridView : MonoBehaviour
    {
        public void SetGridSize(int width, int height)
        {
            gameObject.transform.localScale = new Vector3(width, height, 1);
        }
    }
}