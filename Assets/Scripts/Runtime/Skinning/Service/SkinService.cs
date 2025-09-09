using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

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
            
            if (_gameSkin == null)
            {
                var buildInSkinProvider = _skinProviders[SkinProviderType.BuildIn];
                
                _gameSkin = await buildInSkinProvider.Get(GameSkinType.BuildIn);
                
                Debug.LogError("Game skin not found. Default skin provider will be used as a fallback");
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