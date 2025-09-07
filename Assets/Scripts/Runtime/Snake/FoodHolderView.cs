using UnityEngine;

namespace Snake
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