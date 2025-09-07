using Snake.Window;
using Zenject;

namespace Snake
{
    public class GameOverWindowFactory : BaseWindowFactory<GameOverPresenter,GameOverWindow>
    {
        protected override WindowName WindowName => WindowName.GameOver;

        public GameOverWindowFactory(IWindowProvider provider, DiContainer container) : base(provider, container)
        {
        }
    }
}