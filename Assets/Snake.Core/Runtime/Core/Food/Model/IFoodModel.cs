namespace Snake.Core
{
    public interface IFoodModel
    {
        int Points { get; }
        Vector2Int Position { get; }
    }
}