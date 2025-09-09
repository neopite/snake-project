using UnityEngine;

namespace SnakeView
{
    public class GridView : MonoBehaviour
    {
        [SerializeField]
        private FoodHolderView _foodHolder;
        
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
        
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