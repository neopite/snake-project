using Cysharp.Threading.Tasks;
using UnityEngine;
using Vector2Int = Snake.Core.Vector2Int;

namespace SnakeView
{
    public interface IFoodViewProvider : ISkinnable, IAssetProvider
    {
        FoodView SpawnFood(Vector2Int position);
    }
    
    public class FoodViewProvider : IFoodViewProvider
    {
        private const string PrefabName = "FoodView";

        private FoodView _template;

        public async UniTask Load()
        {
            var foodResult = await Resources.LoadAsync<FoodView>(PrefabName).ToUniTask();

            _template = foodResult as FoodView;
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

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}