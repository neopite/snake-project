using Cysharp.Threading.Tasks;

namespace SnakeView
{
    public interface ISkinProvider
    {
        SkinProviderType Type { get; }
        UniTask<GameSkin> Get(string skinName);
        bool CanProvide(string skinName);
    }
}