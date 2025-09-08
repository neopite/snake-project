using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Snake
{
    public interface ISceneService
    {
        UniTask LoadGameSceneAsync();
        UniTask RestartGameSceneAsync();
    }
    
    public class SceneService : ISceneService
    {
        private const string GameSceneName = "GameScene";
        private const string StartScene = "StartScene";
        
        public async UniTask LoadGameSceneAsync()
        {
            await SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Additive);
            await SceneManager.UnloadSceneAsync(StartScene);
        }

        public async UniTask RestartGameSceneAsync()
        {
            await SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Single);
            await UniTask.Yield();
        }
    }
}