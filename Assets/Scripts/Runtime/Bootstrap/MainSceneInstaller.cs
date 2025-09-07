using Snake.Core;
using Zenject;

namespace Snake
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle();
            
            var snakeModel = new SnakeModel(Vector2Int.Zero);
            var gridModel = new GridModel(10, 10);
            
            Container.Bind<ISnakeModel>().To<SnakeModel>().FromInstance(snakeModel).AsSingle();
            Container.Bind<IGridModel>().To<GridModel>().FromInstance(gridModel).AsSingle();

            Container.BindInterfacesTo<SnakeCollisionService>().AsSingle();
            Container.BindInterfacesTo<SnakeFoodCollector>().AsSingle();
            Container.BindInterfacesTo<SnakeMovementService>().AsSingle();
            
            Container.BindInterfacesTo<FoodSettingsProvider>().AsSingle();
            Container.BindInterfacesTo<FoodSpawner>().AsSingle();
            Container.BindInterfacesTo<FoodService>().AsSingle();
            
            Container.BindInterfacesTo<ScoreModel>().AsSingle();
            
            Container.BindInterfacesTo<GameController>().AsSingle();

            Container.BindInterfacesTo<GameViewRootProvider>().AsSingle();

            Container.BindInterfacesTo<GameControllerPresenter>().AsSingle();
            Container.BindInterfacesTo<FoodViewSpawner>().AsSingle();

        }
    }
}