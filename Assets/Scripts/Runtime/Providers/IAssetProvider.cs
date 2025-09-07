using Cysharp.Threading.Tasks;

namespace Snake.Providers
{
    public interface IAssetProvider
    {
        UniTask Load();
    }
}