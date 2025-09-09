using System;
using Vector2Int = Snake.Core.Vector2Int;

namespace SnakeView
{
    public interface IInputProvider
    {
        event Action<Vector2Int> OnInputDirectionChanged;
    }
}