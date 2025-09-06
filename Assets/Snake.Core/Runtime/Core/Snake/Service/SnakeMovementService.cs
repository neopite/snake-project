namespace Snake.Core
{
    public class SnakeMovementService : ISnakeMovementService
    {
        private readonly SnakeModel _snakeModel;

        public SnakeMovementService(SnakeModel snakeModel)
        {
            _snakeModel = snakeModel;
        }

        public void Move()
        {
            var direction = _snakeModel.Direction;

            var head = _snakeModel.Head;
            
            _snakeModel.AddPartAt(head + direction, 0);
            _snakeModel.RemovePartAt(_snakeModel.PartCount - 1);
        }

        public void SetDirection(Vector2Int newDirection)
        {
            var oldDirection = _snakeModel.Direction;
            
            if (oldDirection + newDirection == Vector2Int.Zero)
            {
                return;
            }

            if (newDirection == Vector2Int.Zero)
            {
                return;
            }
            
            _snakeModel.SetDirection(newDirection);
        }
    }
}