namespace Snake.Core
{
    public interface IFoodModel
    {
        int Points { get; }
        Vector2Int Position { get; }
    }
    
    public class FoodModel : IFoodModel
    {
        public int Points { get; }
        
        public Vector2Int Position { get; }

        public FoodModel(int points, Vector2Int position)
        {
            Points = points;
            Position = position;
        }
    }
}