namespace Snake.Core
{
    public class SnakeCollisionService : ISnakeCollisionService
    {
        private readonly IGridModel _gridModel;
        private readonly ISnakeModel _snakeModel;

        public SnakeCollisionService(IGridModel gridModel, ISnakeModel snakeModel)
        {
            _gridModel = gridModel;
            _snakeModel = snakeModel;
        }

        public bool IsCollided()
        {
            var snake = _snakeModel.Parts;

            var snakeHead = _snakeModel.Head;

            if (!_gridModel.IsInGrid(snakeHead.X, snakeHead.Y))
            {
                return true;
            }

            if (snake.Count == 1)
            {
                return false;
            }
            
            for (var i = 1; i < snake.Count; i++)
            {
                if (snake[i] == snakeHead)
                {
                    return true;
                }
            }

            return false;
        }
    }
}