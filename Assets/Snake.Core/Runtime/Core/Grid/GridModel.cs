namespace Snake.Core
{
    public class GridModel : IGridModel
    {
        public int Width { get; }
        public int Height { get; }

        public GridModel(int width, int height)
        {
            Height = height;
            Width = width;
        }
        
        public bool IsInGrid(int x, int y)
        {
            return x > 0 && x < Width && y > 0 && y < Height;
        }
    }
}