using System;
using Zenject;

namespace Snake
{
    public interface IWindowPresenter<T> : IDisposable where T : WindowBase
    {
        void BindWindow(T window);
        void Initialize();
    }
    
    public abstract class BaseWindowPresenter<T> : IWindowPresenter<T> where T : WindowBase
    {
        protected T Window;
        
        protected SignalBus SignalBus;

        protected BaseWindowPresenter(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void BindWindow(T window)
        {
            Window = window;
        }

        public abstract void Initialize();

        public abstract void Dispose();
    }
}