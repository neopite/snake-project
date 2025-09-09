using System;
using System.Collections.Generic;
using Zenject;

namespace SnakeView
{
    public interface IStateRegister<TState> where TState : struct 
    {
        void Add<TType>(TState state)where TType : class;
        void Register();
        BaseState<TState> Get(TState state);
    }
    
    public class StateRegister<TState> : IStateRegister<TState> where TState : struct
    {
        private readonly DiContainer _diContainer;

        private readonly Dictionary<TState, Type> _states = new();

        public StateRegister(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Add<TType>(TState state)  where TType : class
        {
            _states.Add(state, typeof(TType));
        }

        public void Register()
        {
            foreach (var x in _states)
            {
                var type = x.Value;
                var binding = _diContainer.HasBinding(type);
                if (!binding)
                {
                    _diContainer.Bind(type).To(type).AsTransient();
                }
            }
        }

        public BaseState<TState> Get(TState state)
        {
            if (_states.TryGetValue(state, out var stateType))
            {
                return _diContainer.Resolve(stateType) as BaseState<TState>;
            }

            return null;
        }
    }
}