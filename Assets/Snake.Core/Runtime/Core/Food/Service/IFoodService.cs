namespace Snake.Core
{
    public interface IFoodService
    {
        void PlaceFood();
        bool CanCollectFood(Vector2Int position, out FoodModel foodModel);
    }
}