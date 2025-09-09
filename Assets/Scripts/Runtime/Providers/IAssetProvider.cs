using Cysharp.Threading.Tasks;

namespace SnakeView
{
    public interface IAssetProvider
    {
        UniTask Load();
    }
}