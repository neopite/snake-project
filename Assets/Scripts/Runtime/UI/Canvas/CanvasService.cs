using System;
using System.Collections.Generic;

namespace SnakeView.Canvas
{
    public class CanvasService : ICanvasService
    {
        public event Action<CanvasType>  AddCanvasType;
        
        private readonly Dictionary<CanvasType, UnityEngine.Canvas> _cachedCanvases = new();

        public UnityEngine.Canvas Get(CanvasType type)
        {
            if (_cachedCanvases.TryGetValue(type, out var canvas))
            {
                return canvas;
            }

            return null;
        }
        
        public void Add(CanvasType type, UnityEngine.Canvas canvas)
        {
            _cachedCanvases[type] = canvas;

            AddCanvasType?.Invoke(type);
        }

        public void Remove(CanvasType type)
        {
            _cachedCanvases.Remove(type);
        }
    }
}