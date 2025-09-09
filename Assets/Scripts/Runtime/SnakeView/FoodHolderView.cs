using UnityEngine;

namespace SnakeView
{
    public class FoodHolderView : MonoBehaviour
    {
        private FoodView _current;

        public void SetCurrent(FoodView view)
        {
            _current = view;
        }

        public void DestroyCurrent()
        {
            Destroy(_current.gameObject);
            _current = null;
        }
    }
}