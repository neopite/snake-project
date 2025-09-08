using Snake.Skinning;
using UnityEngine;

namespace Snake
{
    public class GameFacadeView : MonoBehaviour
    {
        [SerializeField] 
        private SnakeView _snake;
        
        [SerializeField]
        private GridView _grid;

        private GameSkin _gameSkin;

        public void SetSnakeBodyTemplate(Sprite body, Sprite corner, Sprite head)
        {
            _snake.InitializeSnakeView(body, corner, head);
        }
        public void SetSkin(GameSkin skin)
        {
            _grid.SetSprite(skin.Background);
        }
        
        public void MoveSnake(Vector2Int moveDirection)
        {
            _snake.MoveSnake(moveDirection);
        }
        
        public void SetGridSize(int width, int height)
        {
            _grid.SetGridSize(width, height);
        }
        
        public void SetFood(FoodView food)
        {
            _grid.SetFood(food);
        }

        public void EatFood()
        {
            _grid.EatFood();
            _snake.Grow();
        }
        
    }
}