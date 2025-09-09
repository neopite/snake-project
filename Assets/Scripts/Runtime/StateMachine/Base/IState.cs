using System;

namespace SnakeView.Base
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
    
    public abstract class BaseState<T> : IState where T : struct
    {
        public event Action<T> OnChangeStateTo;


        public void Enter()
        {
            OnEnter();
        }
        
        public void Exit()
        {
            OnExit();
        }

        protected void ChangeState(T state)
        {
            OnChangeStateTo?.Invoke(state);
        }
        
        public abstract void OnEnter();
        public abstract void OnExit();
    }
}