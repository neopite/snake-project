using UnityEngine;

namespace Snake
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
    
    public abstract class BaseState<T> : IState where T : struct
    {
        public T Name { get; }

        public void Enter()
        {
            Debug.Log($"Entered {Name}");
            OnEnter();
        }
        
        public void Exit()
        {
            Debug.Log($"Exited {Name}");
            OnExit();
        }
        
        public abstract void OnEnter();
        public abstract void OnExit();
    }
}