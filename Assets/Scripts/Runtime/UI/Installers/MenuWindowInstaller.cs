using Zenject;

namespace SnakeView
{
    public class MenuWindowInstaller : Installer<MenuWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuWindowFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuWindowPresenter>().AsSingle();
        }
    }
}