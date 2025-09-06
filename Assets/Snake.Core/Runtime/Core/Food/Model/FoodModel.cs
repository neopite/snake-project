namespace Snake.Core
{
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