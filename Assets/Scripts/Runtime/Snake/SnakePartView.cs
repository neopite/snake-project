using UnityEngine;

namespace Snake
{
    public class SnakePartView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        public void SetPartRotation(float rotationZ)
        {
            _spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }
}