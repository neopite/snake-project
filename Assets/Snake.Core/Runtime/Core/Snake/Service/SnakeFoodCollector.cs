namespace Snake.Core
{
    public class SnakeFoodCollector : ISnakeFoodCollector
    {
        private readonly ISnakeModel _snakeModel;
        private readonly IScoreModel _scoreModel;

        public SnakeFoodCollector(ISnakeModel snakeModel, IScoreModel scoreModel)
        {
            _snakeModel = snakeModel;
            _scoreModel = scoreModel;
        }

        public void CollectFood(IFoodModel model)
        {
            _snakeModel.Grow();
            
            _scoreModel.Increase(model.Points);
        }
    }
}