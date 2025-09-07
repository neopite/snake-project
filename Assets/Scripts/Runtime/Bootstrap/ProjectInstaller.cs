using Zenject;

namespace Snake
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.BindInterfacesTo<GameStateMachineFactory>().AsSingle();
            Container.BindInterfacesTo<AppRoot>().AsSingle();
            
            Container.DeclareSignal<StartGameControllerSignal>();
            Container.DeclareSignal<GameOverSignal>();

        }
    }
}