
using System;
using System.Diagnostics;
using System.Numerics;

namespace Snake.Core
{
    public interface ISnakeMovementService
    {
        void Move();
        void SetDirection(Vector2Int newDirection);
    }
}