using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Vector2Int = Snake.Core.Vector2Int;

namespace Snake
{
    public class InputProvider : IInputProvider, IInitializable, IDisposable
    {
        public event Action<Vector2Int> OnInputDirectionChanged;
        
        private InputSystemActions _inputAction;

        public void Initialize()
        {
            _inputAction = new InputSystemActions();
            
            _inputAction.Enable();

            _inputAction.Player.Move.performed += OnMovePerformed;
        }
        
        private void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            Vector2 value = ctx.ReadValue<Vector2>();

            if (value == Vector2.up)
            {
                OnInputDirectionChanged?.Invoke(Vector2Int.Up);
            }
            else if (value == Vector2.down)
            {
                OnInputDirectionChanged?.Invoke(Vector2Int.Down);
            }
            else if (value == Vector2.left)
            {
                OnInputDirectionChanged?.Invoke(Vector2Int.Left);
            }
            else if (value == Vector2.right)
            {
                OnInputDirectionChanged?.Invoke(Vector2Int.Right);
            }
            
            Debug.Log("Move dir: " + value);
        }

        public void Dispose()
        {
            _inputAction.Player.Move.performed -= OnMovePerformed;
        }
    }
}