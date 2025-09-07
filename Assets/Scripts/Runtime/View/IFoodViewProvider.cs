using Snake.Skinning;
using UnityEngine;
using Zenject;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public interface IFoodViewProvider : ISkinnable
    {
        FoodView SpawnFood(Vector2Int position);
    }
    
    public class FoodViewProvider : IFoodViewProvider, IInitializable
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

        public void ApplySkin(GameSkin skin)
        {
            _template.SetSprite(skin.Food);
        }
    }
}