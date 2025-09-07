using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class CanvasService : ICanvasService
    {
        public event Action<CanvasType>  AddCanvasType;
        
        private readonly Dictionary<CanvasType, Canvas> _cachedCanvases = new();

        public Canvas Get(CanvasType type)
        {
            if (_cachedCanvases.TryGetValue(type, out var canvas))
            {
                return canvas;
            }

            return null;
        }
        
        public void Add(CanvasType type, Canvas canvas)
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