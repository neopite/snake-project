using Snake.Skinning;
using UnityEngine;
using Zenject;

namespace Snake
{
    public interface IGameViewRootProvider : ISkinnable
    {
        GameFacadeView Get();
    }
    
    public class GameViewRootProvider : IGameViewRootProvider, IInitializable
    {
        private GameFacadeView _gameFacadeView;

        public void Initialize()
        {
            _gameFacadeView = Resources.Load<GameFacadeView>("GameRoot");
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