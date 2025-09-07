using UnityEngine;

namespace Snake
{
    public interface ICanvasService
    {
        void Add(CanvasType type, Canvas canvas);
        void Remove(CanvasType type);
        Canvas Get(CanvasType type);
    }

    public enum CanvasType
    {
        MainMenu,
        Game,
    }
}