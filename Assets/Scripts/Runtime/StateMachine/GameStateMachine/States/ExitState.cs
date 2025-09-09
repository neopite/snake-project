using UnityEditor;

namespace SnakeView
{
    public class ExitState : BaseState<GameState>
    {
        public override void Enter()
        {
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }

        public override void Exit()
        {
        }
    }
}