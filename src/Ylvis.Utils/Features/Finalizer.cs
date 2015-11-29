using System;

namespace Ylvis.Utils.Features
{
    public class Finalizer : IDisposable
    {
        public Action ActToRunOnDispose { get; set; }

        public Finalizer(Action actToRunOnDispose)
        {
            ActToRunOnDispose = actToRunOnDispose;
        }

        public void Dispose()
        {
            ActToRunOnDispose();
        }
    }
}