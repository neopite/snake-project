using UnityEngine;

namespace Snake
{
    public class ExitState : BaseState<GameState>
    {
        public override void OnEnter()
        {
            Application.Quit();
        }

        public override void OnExit()
        {
        }
    }
}