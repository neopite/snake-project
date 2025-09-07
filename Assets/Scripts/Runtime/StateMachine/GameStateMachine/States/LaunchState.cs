namespace Snake
{
    public class LaunchState : BaseState<GameState>
    {
        public override void OnEnter()
        {
            ChangeState(GameState.Menu);
        }

        public override void OnExit()
        {
        }
    }
}