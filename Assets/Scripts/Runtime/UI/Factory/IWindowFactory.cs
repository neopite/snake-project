using UnityEngine;
using Zenject;

namespace SnakeView
{
    public interface IWindowFactory
    {
         WindowBase Construct(Transform root);
    }

    public abstract class BaseWindowFactory<TPresenter, TView> : IWindowFactory where TPresenter : IWindowPresenter<TView>
        where TView : WindowBase
    {
        protected abstract WindowName WindowName { get; }
        
        protected readonly IWindowProvider Provider;
        protected readonly DiContainer Container;

        protected BaseWindowFactory(IWindowProvider provider, DiContainer container)
        {
            Provider = provider;
            Container = container;
        }

        public WindowBase Construct(Transform root)
        {
            var template = (TView)Provider.Get(WindowName);
            var windowBase = Object.Instantiate(template, root);

            var presenter = Container.Resolve<TPresenter>();
            
            presenter.BindWindow(windowBase);
            
            presenter.Initialize();

            return windowBase;
        }
    }
}