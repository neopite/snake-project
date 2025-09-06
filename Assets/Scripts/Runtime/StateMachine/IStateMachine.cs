using System;

namespace Snake
{
    public interface IStateMachine<TState> where TState : struct
    {
        event Action OnStateChanged;
        
        TState CurrentState { get; }

        void Switch(TState state);
        
        void SetRegister(IStateRegister<TState> register);
    }
    
    public class BaseStateMachine<TState> : IStateMachine<TState> where TState : struct
    {
        public event Action OnStateChanged;
        public TState CurrentState { get; private set;}
        private BaseState<TState> _currentState;
        
        private IStateRegister<TState> _register;
        
        public void Switch(TState newState)
        {
            var state = _register.Get(newState);
            _currentState?.Exit();
            state.Enter();
            _currentState = state;
            CurrentState = _currentState.Name;
        }

        public void SetRegister(IStateRegister<TState> register)
        {
            _register = register;

            _register.Register();
        }
        
    }
}