using UnityEngine;
using Zenject;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public interface IFoodViewSpawner
    {
        FoodView SpawnFood(Vector2Int position);
    }
    
    public class FoodViewSpawner : IFoodViewSpawner, IInitializable
    {
        private const string PrefabName = "FoodView";

        private FoodView _template;

        public void Initialize()
        {
            _template = Resources.Load<FoodView>(PrefabName);
        }

        public FoodView SpawnFood(Vector2Int position)
        {
            var pos = new Vector3(position.X, position.Y, 0);
            return Object.Instantiate(_template, pos, Quaternion.identity);
        }

    }
}