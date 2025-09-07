using UnityEngine;

namespace Snake
{
    public class GridView : MonoBehaviour
    {
        [SerializeField]
        private FoodHolderView _foodHolder;
        
        public void SetGridSize(int width, int height)
        {
            gameObject.transform.localScale = new Vector3(width, height, 1);
        }

        public void SetFood(FoodView food)
        {
            _foodHolder.SetCurrent(food);
        }

        public void EatFood()
        {
            _foodHolder.DestroyCurrent();
        }
    }
}