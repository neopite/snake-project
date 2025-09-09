using Zenject;

namespace SnakeView
{
    public class MainMenuWindowFactory : BaseWindowFactory<MainMenuWindowPresenter, MainMenuWindow>
    {
        protected override WindowName WindowName => WindowName.MainMenu;

        public MainMenuWindowFactory(IWindowProvider provider, DiContainer container) : base(provider, container)
        {
        }
    }
}