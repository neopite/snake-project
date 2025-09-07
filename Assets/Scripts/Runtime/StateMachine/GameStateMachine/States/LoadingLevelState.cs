using Cysharp.Threading.Tasks;
using Snake.Skinning;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class LoadingLevelState : BaseState<GameState>
    {
        private const string GameSceneName = "GameScene";
        private const string StartScene = "StartScene";
        
        private readonly ISkinService _skinService;

        public LoadingLevelState(
            ISkinService skinService)
        {
            _skinService = skinService;
        }

        public async override void OnEnter()
        {
            await SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Additive);
            await SceneManager.UnloadSceneAsync(StartScene);

            var gameSkin = await _skinService.GetSkin();
            
            _skinService.ApplySkin(gameSkin);

            ChangeState(GameState.Play);
        }

        public override void OnExit()
        {
        }
    }
}