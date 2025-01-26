using System;
using Zenject;

namespace Core.MVP
{
	public abstract class PresenterBase <TModel, TView> : IInitializable, IDisposable
	{
		protected TModel Model
		{
			get; private set;
		}
		protected TView View
		{
			get; private set;
		}

        public PresenterBase()
        {
            
        }

        [Inject]
        public void Init(TModel model, TView view)
        {
			Model = model;
			View = view;
		}

		public virtual void Initialize()
		{
			Present();
		}

		protected abstract void Present();

		public abstract void Dispose();
	}
}
