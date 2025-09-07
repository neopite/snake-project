using System;
using System.Linq;

namespace Snake.Core
{
    public class FoodSpawner : IFoodSpawner
    {
        public readonly IGridModel _gridModel;
        public readonly ISnakeModel _snakeModel;
        public readonly IFoodSettingsProvider _foodSettingsProvider;

        private readonly Random _random = new();

        public FoodSpawner(
            IGridModel gridModel,
            ISnakeModel snakeModel,
            IFoodSettingsProvider foodSettingsProvider)
        {
            _gridModel = gridModel;
            _snakeModel = snakeModel;
            _foodSettingsProvider = foodSettingsProvider;
        }

        public FoodModel Spawn()
        {
            var busyCells = _snakeModel.Parts;
            var gridHeight = _gridModel.Height;
            var gridWidth = _gridModel.Width;

            Vector2Int spawnPos;
            
            //Change implementation on more reliable 
            do
            {
                var x = _random.Next(0, gridWidth);
                var y = _random.Next(0, gridHeight);
                spawnPos = new Vector2Int(x, y);
            } while (busyCells.Contains(spawnPos));

            var points = _foodSettingsProvider.GetFoodScore();
            
            return new FoodModel(points, spawnPos);
        }
    }
}