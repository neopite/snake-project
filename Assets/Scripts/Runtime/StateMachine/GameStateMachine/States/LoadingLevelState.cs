using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class LoadingLevelState : BaseState<GameState>
    {
        private const string GameSceneName = "GameScene";
        private const string StartScene = "StartScene";
        
        public async override void OnEnter()
        {
            await SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Additive);
            await SceneManager.UnloadSceneAsync(StartScene);
            ChangeState(GameState.Play);
        }

        public override void OnExit()
        {
        }
    }
}