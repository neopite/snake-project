using Snake.Skinning;
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
            
            BindProviders();
            BindSkinningServices();
        }
        
        private void BindProviders()
        {
            Container.BindInterfacesTo<GameViewRootProvider>().AsSingle();
            Container.BindInterfacesTo<SnakePartProvider>().AsSingle();
            Container.BindInterfacesTo<FoodViewProvider>().AsSingle();
        }
        
        private void BindSkinningServices()
        {
            Container.Bind<BuildInSkinProvider>().To<BuildInSkinProvider>().AsSingle();
            Container.Bind<AssetBundleSkinProvider>().To<AssetBundleSkinProvider>().AsSingle();
            
            Container.BindInterfacesTo<SkinService>().AsSingle();
        }
    }
}