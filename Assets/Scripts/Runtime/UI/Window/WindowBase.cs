using System;
using UnityEngine;

namespace Snake
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