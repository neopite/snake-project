using System.Collections.Generic;

namespace Snake.Core
{
    public interface ISnakeModel
    {
        Vector2Int Direction { get; }
        
        Vector2Int Tail { get; }
        Vector2Int Head { get; }
        int PartCount { get; }
        
        IReadOnlyList<Vector2Int> Parts { get; }

        void SetDirection(Vector2Int direction);
        void AddPartAt(Vector2Int part, int index);
        void RemovePartAt(int index);
    }
}