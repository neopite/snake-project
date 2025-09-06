namespace Snake.Core
{
    public interface IGridModel
    {
        int Width { get; }
        int Height { get; }
        bool IsInGrid(int x, int y);
    }
}