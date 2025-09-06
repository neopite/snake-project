namespace Snake.Core
{
    public class SnakeCollisionService : ISnakeCollisionService
    {
        private readonly GridModel _gridModel;
        private readonly SnakeModel _snakeModel;

        public SnakeCollisionService(GridModel gridModel, SnakeModel snakeModel)
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