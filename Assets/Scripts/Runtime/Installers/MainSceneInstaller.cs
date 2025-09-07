using Snake.Core;
using Snake.Skinning;
using Zenject;

namespace Snake
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindModels();
            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<InputProvider>().AsSingle();
            
            Container.BindInterfacesTo<SnakeCollisionService>().AsSingle();
            Container.BindInterfacesTo<SnakeFoodCollector>().AsSingle();
            Container.BindInterfacesTo<SnakeMovementService>().AsSingle();
            
            Container.BindInterfacesTo<FoodSettingsProvider>().AsSingle();
            Container.BindInterfacesTo<FoodSpawner>().AsSingle();
            Container.BindInterfacesTo<FoodService>().AsSingle();
            
            Container.BindInterfacesTo<ScoreModel>().AsSingle();
            Container.BindInterfacesTo<GameLoopController>().AsSingle();
            Container.BindInterfacesTo<GameControllerPresenter>().AsSingle();

            BindProviders();
        }

        private void BindModels()
        {
            Container.Bind<IGridModel>()
                .To<GridModel>()
                .AsSingle()
                .WithArguments(10, 10);

            Container.Bind<ISnakeModel>()
                .To<SnakeModel>()
                .AsSingle()
                .WithArguments(Vector2Int.Zero);
        }

        private void BindProviders()
        {
            Container.BindInterfacesTo<GameViewRootProvider>().AsSingle();
            Container.BindInterfacesTo<SnakePartProvider>().AsSingle();
            Container.BindInterfacesTo<FoodViewProvider>().AsSingle();
        }
    }
}