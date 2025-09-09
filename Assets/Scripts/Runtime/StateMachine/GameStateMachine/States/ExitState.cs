using UnityEngine;

namespace SnakeView
{
    public class ExitState : BaseState<GameState>
    {
        public override void Enter()
        {
            Application.Quit();
        }

        public override void Exit()
        {
        }
    }
}