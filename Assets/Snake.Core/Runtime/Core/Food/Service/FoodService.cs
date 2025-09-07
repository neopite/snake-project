namespace Snake.Core
{
    public class FoodService : IFoodService
    {
        private readonly IFoodSpawner _foodSpawner;
        
        private FoodModel _currentFood;
        
        public Vector2Int CurrentFoodPosition => _currentFood.Position;

        public FoodService(IFoodSpawner foodSpawner)
        {
            _foodSpawner = foodSpawner;
        }

        public void PlaceFood()
        {
            var foodToSpawn = _foodSpawner.Spawn();
            _currentFood = foodToSpawn;
        }

        public bool CanCollectFood(Vector2Int position, out FoodModel food)
        {
            food = null;
            
            if (_currentFood?.Position == position)
            {
                food = _currentFood;
            }

            return _currentFood?.Position == position;
        }
    }
}