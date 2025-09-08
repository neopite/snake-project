using UnityEngine;
using Zenject;

namespace Snake.Skinning
{
    [CreateAssetMenu(fileName = "SkinInstaller", menuName = "Snake/Installers/SkinInstaller")]
    public class GameSkinConfigInstaller : ScriptableObjectInstaller<GameSkinConfigInstaller>
    {
        [SerializeField] 
        private GameSkinConfig _skinConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_skinConfig).IfNotBound();
        }
    }
}