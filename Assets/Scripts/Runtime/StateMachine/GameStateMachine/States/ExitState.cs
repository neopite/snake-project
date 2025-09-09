using SnakeView.Base;
using UnityEngine;

namespace SnakeView.GameStateMachine.States
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