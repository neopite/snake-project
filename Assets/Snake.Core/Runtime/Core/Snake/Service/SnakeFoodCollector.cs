namespace Snake.Core
{
    public class SnakeFoodCollector : ISnakeFoodCollector
    {
        private readonly ISnakeModel _snakeModel;
        private readonly ScoreModel _scoreModel;

        public SnakeFoodCollector(ISnakeModel snakeModel, ScoreModel scoreModel)
        {
            _snakeModel = snakeModel;
            _scoreModel = scoreModel;
        }

        public void CollectFood(FoodModel model)
        {
            _snakeModel.Grow();
            
            _scoreModel.Increase(model.Points);
        }
    }
}