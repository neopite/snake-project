using Snake;
using Snake.Core;
using SnakeView.Canvas;
using SnakeView.GameStateMachine;
using Zenject;

namespace SnakeView
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
            InstallWindows();
            
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

        private void InstallWindows()
        {
            GameOverWindowInstaller.Install(Container);
            HudWindowInstaller.Install(Container);
            MenuWindowInstaller.Install(Container);
        }
        
        private void BindSkinningServices()
        {
            Container.BindInterfacesTo<BuildInSkinProvider>().AsSingle();
            Container.BindInterfacesTo<AssetBundleSkinProvider>().AsSingle();
            
            Container.BindInterfacesTo<SkinService>().AsSingle();
        }
    }
}