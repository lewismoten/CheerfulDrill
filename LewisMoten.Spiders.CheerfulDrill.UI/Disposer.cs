using System;
using System.ComponentModel;

namespace LewisMoten.Spiders.CheerfulDrill.UI
{
    internal class Disposer : IComponent
    {
        private readonly Action _disposeAction;

        public Disposer(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }

        public ISite Site { get; set; }
        public event EventHandler Disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            _disposeAction();
            if (Disposed != null)
            {
                Disposed(this, EventArgs.Empty);
            }
        }
    }
}