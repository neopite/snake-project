using UnityEngine;

namespace Snake
{
    public interface IGameViewRootProvider
    {
        GameFacadeView Get();
    }
    
    public class GameViewRootProvider : IGameViewRootProvider
    {
        public GameFacadeView Get()
        {
            return Resources.Load<GameFacadeView>("GameRoot");
        }
    }
}