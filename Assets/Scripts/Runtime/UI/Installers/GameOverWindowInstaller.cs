using Zenject;

namespace SnakeView
{
    public class GameOverWindowInstaller : Installer<GameOverWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameOverWindowFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverPresenter>().AsSingle();
        }
    }
}