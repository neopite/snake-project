using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Snake.Providers;
using Snake.Skinning;
using UnityEngine;
namespace Snake.Window
{
    public interface IWindowProvider : IAssetProvider
    {
        WindowBase Get(WindowName name);
    }
    
    public class WindowProvider : IWindowProvider
    {
        private const string MainMenuWindow = "MainMenuWindow";
        private const string HudWindow = "HudWindow";
        private const string GameOverWindow = "GameOverWindow";
        
        private Dictionary<WindowName, WindowBase> _windows = new ();

        public async UniTask Load()
        {
            var mainMenuObject = await Resources.LoadAsync<WindowBase>(MainMenuWindow).ToUniTask();
            var hudWindowObject = await Resources.LoadAsync<WindowBase>(HudWindow).ToUniTask();
            var gameOverObject = await Resources.LoadAsync<WindowBase>(GameOverWindow).ToUniTask();
            
            _windows.Add(WindowName.MainMenu, mainMenuObject as WindowBase);
            _windows.Add(WindowName.GameOver, gameOverObject as WindowBase);
            _windows.Add(WindowName.Hud, hudWindowObject as WindowBase);
        }

        public WindowBase Get(WindowName name)
        {
            return _windows[name];
        }
    }
}