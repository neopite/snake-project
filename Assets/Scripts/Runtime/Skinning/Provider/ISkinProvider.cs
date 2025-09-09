using Cysharp.Threading.Tasks;

namespace SnakeView
{
    public interface ISkinProvider
    {
        SkinProviderType Type { get; }
        UniTask<GameSkin> Get(GameSkinType skinType);
        bool CanProvide(GameSkinType skinType);
    }
}