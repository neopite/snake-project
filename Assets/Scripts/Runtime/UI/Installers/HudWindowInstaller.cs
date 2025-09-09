using Zenject;

namespace SnakeView
{
    public class HudWindowInstaller : Installer<HudWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HudWindowFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<HudWindowPresenter>().AsSingle();
        }
    }
}