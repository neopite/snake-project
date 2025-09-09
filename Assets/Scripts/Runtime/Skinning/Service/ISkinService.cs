using Cysharp.Threading.Tasks;

namespace SnakeView
{
    public interface ISkinService
    {
        UniTask<GameSkin> GetSkin(string skinName);
        void ApplySkin(GameSkin skin);
    }

    [System.Serializable]
    public enum GameSkinType
    {
        BuildIn,
        Cubic,
        Casual
    }
}