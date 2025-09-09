using Zenject;

namespace SnakeView
{
    public class HudWindowFactory : BaseWindowFactory<HudWindowPresenter, HudWindow>
    {
        protected override WindowName WindowName => WindowName.Hud;

        public HudWindowFactory(IWindowProvider provider, DiContainer container) : base(provider, container)
        {
        }
    }
}