using UnityEngine;
using Zenject;

namespace Snake
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("ProjectInstaller.InstallBindings called!");

            Container.BindInterfacesTo<GameStateMachineFactory>().AsSingle();
            Container.BindInterfacesTo<AppRoot>().AsSingle();
        }
        
    }
}