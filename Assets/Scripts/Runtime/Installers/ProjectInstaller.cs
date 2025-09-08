using Snake.Core;
using Snake.Skinning;
using Snake.Window;
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
            Container.DeclareSignal<ExitApplicationSignal>();
            Container.DeclareSignal<LoadLevelSignal>();
            Container.DeclareSignal<PlayAgainSignal>();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<GameStateMachineFactory>().AsSingle();
            Container.BindInterfacesTo<AppRoot>().AsSingle();
            Container.BindInterfacesTo<WindowService>().AsSingle();
            Container.BindInterfacesTo<CanvasService>().AsSingle();
            
            BindProviders();
            BindSkinningServices();
            BindWindowPresenter();
            BindWindowFactory();
            
            Container.BindInterfacesTo<ScoreModel>().AsSingle();
            Container.BindInterfacesTo<SceneService>().AsSingle();
        }
        
        private void BindProviders()
        {
            Container.BindInterfacesTo<GameViewRootProvider>().AsSingle();
            Container.BindInterfacesTo<SnakeAssetProvider>().AsSingle();
            Container.BindInterfacesTo<FoodViewProvider>().AsSingle();
            Container.BindInterfacesTo<WindowProvider>().AsSingle();
        }

        private void BindWindowFactory()
        {
            Container.BindInterfacesAndSelfTo<MainMenuWindowFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<HudWindowFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverWindowFactory>().AsSingle();
        }
        private void BindWindowPresenter()
        {
            Container.BindInterfacesAndSelfTo<MainMenuWindowPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<HudWindowPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverPresenter>().AsSingle();
        }
        
        private void BindSkinningServices()
        {
            Container.Bind<BuildInSkinProvider>().To<BuildInSkinProvider>().AsSingle();
            Container.Bind<AssetBundleSkinProvider>().To<AssetBundleSkinProvider>().AsSingle();
            
            Container.BindInterfacesTo<SkinService>().AsSingle();
        }
    }
}