namespace Snake.Core
{
    public interface ISnakeMovementService
    {
        void Move();
        void SetDirection(Vector2Int newDirection);
    }
}