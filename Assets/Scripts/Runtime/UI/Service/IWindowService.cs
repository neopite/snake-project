using UnityEngine;

namespace SnakeView
{
    public interface IWindowService
    {
        void Add(WindowName window);
        void RemoveCurrent();
        bool HasCurrent();
        void SetRoot(Transform root);
    }

    public enum WindowName
    {
        MainMenu,
        Hud,
        GameOver
    }
}