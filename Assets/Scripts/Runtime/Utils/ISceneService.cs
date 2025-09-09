using Cysharp.Threading.Tasks;

namespace SnakeView
{
    public interface ISceneService
    {
        UniTask LoadGameSceneAsync();
        UniTask RestartGameSceneAsync();
    }
}