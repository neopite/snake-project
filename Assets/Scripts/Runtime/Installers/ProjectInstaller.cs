using Zenject;

namespace Snake
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            BindSignals();
            BindServices();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<LaunchGameControllerSignal>();
            Container.DeclareSignal<GameOverSignal>();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<GameStateMachineFactory>().AsSingle();
            Container.BindInterfacesTo<AppRoot>().AsSingle();
        }
    }
}