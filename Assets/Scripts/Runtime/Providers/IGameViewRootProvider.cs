using Cysharp.Threading.Tasks;
using Snake.Providers;
using Snake.Skinning;
using UnityEngine;
using Zenject;

namespace Snake
{
    public interface IGameViewRootProvider : ISkinnable, IAssetProvider
    {
        GameFacadeView Get();
    }
    
    public class GameViewRootProvider : IGameViewRootProvider
    {
        private GameFacadeView _gameFacadeView;

        public async UniTask Load()
        {
            var rootLoadObject = await Resources.LoadAsync<GameFacadeView>("GameRoot").ToUniTask();
            
            _gameFacadeView = rootLoadObject as GameFacadeView;
        }

        public void Initialize()
        {
        }

        public GameFacadeView Get()
        {
            return _gameFacadeView;
        }

        public void ApplySkin(GameSkin skin)
        {
            _gameFacadeView.SetSkin(skin);
        }
    }
}