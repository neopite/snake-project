using System;
using System.Collections.Generic;
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
            var busyCells = new HashSet<Vector2Int>(_snakeModel.Parts);
            var gridHeight = _gridModel.Height;
            var gridWidth = _gridModel.Width;

            var freeCells = new List<Vector2Int>();
            for (var x = 0; x < gridWidth; x++)
            {
                for (var y = 0; y < gridHeight; y++)
                {
                    var pos = new Vector2Int(x, y);
                    if (!busyCells.Contains(pos))
                    {
                        freeCells.Add(pos);
                    }
                }
            }

            if (freeCells.Count == 0)
            {
                return null;
            }

            var spawnPos = freeCells[_random.Next(freeCells.Count)];

            var points = _foodSettingsProvider.GetFoodScore();
            return new FoodModel(points, spawnPos);
        }
    }
}