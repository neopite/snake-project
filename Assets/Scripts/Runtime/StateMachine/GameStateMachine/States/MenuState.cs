namespace Snake
{
    public class MenuState : BaseState<GameState>
    {
        public override void OnEnter()
        {
            ChangeState(GameState.LoadingLevel);
        }

        public override void OnExit()
        {
        }
    }
}