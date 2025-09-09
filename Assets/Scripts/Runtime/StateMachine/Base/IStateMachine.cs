using System;
using UnityEngine;

namespace SnakeView
{
    public interface IStateMachine<TState> where TState : struct
    {
        void Switch(TState state);
        
        void SetRegister(IStateRegister<TState> register);
    }
    
    public class BaseStateMachine<TState> : IDisposable, IStateMachine<TState> where TState : struct
    {
        private BaseState<TState> _currentState;
        
        private IStateRegister<TState> _register;
        
        public void Switch(TState newState)
        {
            var state = _register.Get(newState);
            _currentState?.Exit();
            
            state.OnChangeStateTo += OnChangedStateTo;
            _currentState = state;
            state.Enter();
            
            Debug.Log($"Switched to : {newState}");
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