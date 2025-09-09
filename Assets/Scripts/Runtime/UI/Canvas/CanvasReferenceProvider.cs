using UnityEngine;
using Zenject;

namespace SnakeView.Canvas
{
    public class CanvasReferenceProvider : MonoBehaviour
    {
        [Header("Structure")]
        [SerializeField]
        private UnityEngine.Canvas _canvas;

        [SerializeField]
        private CanvasType _canvasType;

        [Inject]
        private readonly ICanvasService _canvasService;

        private void Start()
        {
            _canvasService.Add(_canvasType, _canvas);
        }
    }
}