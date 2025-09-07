namespace Snake.Core
{
    public interface IFoodService
    {
        public Vector2Int CurrentFoodPosition { get; }
        void PlaceFood();
        bool CanCollectFood(Vector2Int position, out FoodModel foodModel);
    }
}