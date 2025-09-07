using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class ReloadState : BaseState<GameState>
    {

        public async override void OnEnter()
        {
            await SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
            await UniTask.Delay(TimeSpan.FromSeconds(0.4f));
            ChangeState(GameState.Play);
        }

        public override void OnExit()
        {
        }
    }
}