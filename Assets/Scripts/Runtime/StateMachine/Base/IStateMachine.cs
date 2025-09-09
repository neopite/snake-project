using System;
using UnityEngine;

namespace SnakeView.Base
{
    public interface IStateMachine<TState> where TState : struct
    {
        event Action OnStateChanged;
        
        TState CurrentState { get; }

        void Switch(TState state);
        
        void SetRegister(IStateRegister<TState> register);
    }
    
    public class BaseStateMachine<TState> : IDisposable, IStateMachine<TState> where TState : struct
    {
        public event Action OnStateChanged;
        public TState CurrentState { get; private set;}
        private BaseState<TState> _currentState;
        
        private IStateRegister<TState> _register;
        
        public void Switch(TState newState)
        {
            var state = _register.Get(newState);
            _currentState?.Exit();
            state.OnChangeStateTo += OnChangedStateTo;
            _currentState = state;
            CurrentState = newState;
            state.Enter();
            
            Debug.Log($"Switched to : {newState}");
            OnStateChanged?.Invoke();
        }

        private void OnChangedStateTo(TState newState)
        {
            _currentState.OnChangeStateTo -= OnChangedStateTo;
            
            Switch(newState);
        }

        public void SetRegister(IStateRegister<TState> register)
        {
            _register = register;

            _register.Register();
        }

        public void Dispose()
        {
            if (_currentState != null)
            {
                _currentState.OnChangeStateTo -= OnChangedStateTo;
            }
        }
    }
}