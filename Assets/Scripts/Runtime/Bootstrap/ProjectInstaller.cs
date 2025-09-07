using Zenject;

namespace Snake
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameStateMachineFactory>().AsSingle();
            Container.BindInterfacesTo<AppRoot>().AsSingle();
        }
        
    }
}