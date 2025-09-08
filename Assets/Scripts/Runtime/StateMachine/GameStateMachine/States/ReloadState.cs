namespace Snake
{
    public class ReloadState : BaseState<GameState>
    {
        private readonly ISceneService _sceneService;

        public ReloadState(ISceneService sceneService)
        {
            _sceneService = sceneService;
        }

        public async override void OnEnter()
        {
            await _sceneService.RestartGameSceneAsync();
            ChangeState(GameState.Play);
        }

        public override void OnExit()
        {
        }
    }
}