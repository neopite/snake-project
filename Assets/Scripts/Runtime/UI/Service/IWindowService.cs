using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace SnakeView
{
    public interface IWindowService
    {
        void Add(WindowName window);
        void RemoveCurrent();
        bool HasCurrent();
        void SetRoot(Transform root);
    }
    
    public class WindowService : IWindowService, IInitializable
    {
        private readonly DiContainer _container;
        
        private Transform _root;
        private WindowBase _currentWindow;

        private readonly MainMenuWindowFactory _mainMenuWindowFactory;
        private readonly HudWindowFactory _hudWindowFactory;
        private readonly GameOverWindowFactory _gameOverWindowFactory;

        private readonly Dictionary<WindowName, IWindowFactory> _windowFactory = new();

        public WindowService(
            MainMenuWindowFactory mainMenuWindowFactory,
            HudWindowFactory hudWindowFactory,
            GameOverWindowFactory gameOverWindowFactory)
        {
            _mainMenuWindowFactory = mainMenuWindowFactory;
            _hudWindowFactory = hudWindowFactory;
            _gameOverWindowFactory = gameOverWindowFactory;
        }

        public void Initialize()
        {
            _windowFactory.Add(WindowName.MainMenu, _mainMenuWindowFactory);
            _windowFactory.Add(WindowName.Hud, _hudWindowFactory);
            _windowFactory.Add(WindowName.GameOver, _gameOverWindowFactory);
        }

        public void Add(WindowName name)
        {
            var windowBase = _windowFactory[name].Construct(_root);
            _currentWindow = windowBase;

            _currentWindow.OnClosed += OnWindowClosed;
        }

        public void RemoveCurrent()
        {
            if (HasCurrent())
            {
                Object.Destroy(_currentWindow.gameObject);
                _currentWindow = null;
            }
        }

        public bool HasCurrent()
        {
            return _currentWindow != null;
        }

        public void SetRoot(Transform root)
        {
            _root = root;
        }

        private void OnWindowClosed()
        {
            _currentWindow.OnClosed -= OnWindowClosed;
            
            RemoveCurrent();
        }
    }

    public enum WindowName
    {
        MainMenu,
        Hud,
        GameOver
    }
}