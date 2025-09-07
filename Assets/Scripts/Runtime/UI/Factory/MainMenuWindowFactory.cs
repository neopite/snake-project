using Snake.Window;
using Zenject;

namespace Snake
{
    public class MainMenuWindowFactory : BaseWindowFactory<MainMenuWindowPresenter, MainMenuWindow>
    {
        protected override WindowName WindowName => WindowName.MainMenu;

        public MainMenuWindowFactory(IWindowProvider provider, DiContainer container) : base(provider, container)
        {
        }
    }
}