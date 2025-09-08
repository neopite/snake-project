using Snake.Core;

namespace Snake
{
    public class ReloadState : BaseState<GameState>
    {
        private readonly ISceneService _sceneService;
        private readonly IScoreModel _scoreModel;

        public ReloadState(ISceneService sceneService, IScoreModel scoreModel)
        {
            _sceneService = sceneService;
            _scoreModel = scoreModel;
        }

        public async override void OnEnter()
        {
            await _sceneService.RestartGameSceneAsync();
            _scoreModel.Reset();
            ChangeState(GameState.Play);
        }

        public override void OnExit()
        {
        }
    }
}