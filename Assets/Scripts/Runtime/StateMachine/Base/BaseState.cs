using System;

namespace SnakeView
{
    public abstract class BaseState<T> where T : struct
    {
        public event Action<T> OnChangeStateTo;

        public abstract void Enter();
        public abstract void Exit();

        protected void ChangeState(T state)
        {
            OnChangeStateTo?.Invoke(state);
        }
    }
}