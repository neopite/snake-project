using System;
using UnityEngine;

namespace SnakeView
{
    public class WindowBase : MonoBehaviour
    {
        public event Action OnClosed;

        public void Close()
        {
            OnClosed?.Invoke();
        }
    }
}