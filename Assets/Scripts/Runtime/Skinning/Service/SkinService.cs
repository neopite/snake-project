using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace SnakeView
{
    public class SkinService : ISkinService
    {
        private readonly List<ISkinnable> _skinnables = new();
        
        private Dictionary<SkinProviderType, ISkinProvider> _skinProviders = new();
        
        private GameSkin _gameSkin;

        public SkinService(
            IEnumerable<ISkinnable> skinnables, 
            IEnumerable<ISkinProvider> skinProviders)
        {
            _skinnables = new List<ISkinnable>(skinnables);
            _skinProviders = new Dictionary<SkinProviderType, ISkinProvider>();

            foreach (var x in skinProviders)
            {
                _skinProviders.Add(x.Type, x);
            }
        }

        public async UniTask<GameSkin> GetSkin(GameSkinType skinType)
        {
            foreach (var x in _skinProviders)
            {
                if (x.Value.CanProvide(skinType))
                {
                    _gameSkin = await x.Value.Get(skinType);
                }
            }
            
            return _gameSkin;
        }

        public void ApplySkin(GameSkin skin)
        {
            foreach (var x in _skinnables)
            {
                x.ApplySkin(skin);
            }
        }
    }
}