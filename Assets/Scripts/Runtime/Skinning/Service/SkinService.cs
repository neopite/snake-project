using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SnakeView.Config;
using UnityEngine;

namespace SnakeView
{
    public class SkinService : ISkinService
    {
        private readonly List<ISkinnable> _skinnables = new();
        
        private Dictionary<SkinProviderType, ISkinProvider> _skinProviders = new();
        
        private GameSkin _gameSkin;
        
        private GameSkinConfig _skinConfig;

        public SkinService(
            IEnumerable<ISkinnable> skinnables, 
            IEnumerable<ISkinProvider> skinProviders,
            GameSkinConfig skinConfig)
        {
            _skinConfig = skinConfig;
            _skinnables = new List<ISkinnable>(skinnables);
            _skinProviders = new Dictionary<SkinProviderType, ISkinProvider>();

            foreach (var x in skinProviders)
            {
                _skinProviders.Add(x.Type, x);
            }
        }

        public async UniTask<GameSkin> GetSkin(string skinName)
        {
            foreach (var x in _skinProviders)
            {
                if (x.Value.CanProvide(skinName))
                {
                    _gameSkin = await x.Value.Get(skinName);
                }
            }
            
            if (_gameSkin == null)
            {
                var buildInSkinProvider = _skinProviders[SkinProviderType.BuildIn];
                
                _gameSkin = await buildInSkinProvider.Get(_skinConfig.BuildInSkinFallback);
                
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