namespace SnakeView.Canvas
{
    public interface ICanvasService
    {
        void Add(CanvasType type, UnityEngine.Canvas canvas);
        void Remove(CanvasType type);
        UnityEngine.Canvas Get(CanvasType type);
    }

    public enum CanvasType
    {
        MainMenu,
        Game,
    }
}