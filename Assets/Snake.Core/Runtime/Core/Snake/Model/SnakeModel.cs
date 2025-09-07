using System.Collections.Generic;

namespace Snake.Core
{
    public class SnakeModel : ISnakeModel
    {
        private List<Vector2Int> _parts;
        private Vector2Int _direction = new(0, 0);
        
        public Vector2Int Direction => _direction;
        
        public Vector2Int Tail => _parts[^1];
        public Vector2Int Head => _parts[0];
        public int PartCount => _parts.Count;
        public IReadOnlyList<Vector2Int> Parts => _parts;

        public SnakeModel(Vector2Int initialPosition)
        {
            _parts = new List<Vector2Int> { initialPosition };
        }

        public void SetDirection(Vector2Int direction)
        {
            _direction = direction;
        }

        public void AddPartAt(Vector2Int part, int index)
        {
            _parts.Insert(index, part);
        }

        public void RemovePartAt(int index)
        {
            _parts.RemoveAt(index);
        }

        public void Grow()
        {
            _parts.Add(Tail);
        }
    }
}