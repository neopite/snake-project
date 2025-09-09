using Cysharp.Threading.Tasks;

namespace SnakeView
{
    public interface ISkinService
    {
        UniTask<GameSkin> GetSkin(string skinName);
        void ApplySkin(GameSkin skin);
    }
}