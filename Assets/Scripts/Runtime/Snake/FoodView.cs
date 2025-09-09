using UnityEngine;

namespace SnakeView
{
    public class FoodView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}