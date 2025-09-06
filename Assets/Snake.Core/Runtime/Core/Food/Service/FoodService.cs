namespace Snake.Core
{
    public class FoodService : IFoodService
    {
        private readonly IFoodSpawner _foodSpawner;
        
        private FoodModel _currentFood;

        public FoodService(IFoodSpawner foodSpawner)
        {
            _foodSpawner = foodSpawner;
        }

        public void PlaceFood()
        {
            var foodToSpawn = _foodSpawner.Spawn();
            _currentFood = foodToSpawn;
        }

        public bool CanCollectFood(Vector2Int position)
        {
            return _currentFood.Position == position;
        }
    }
}