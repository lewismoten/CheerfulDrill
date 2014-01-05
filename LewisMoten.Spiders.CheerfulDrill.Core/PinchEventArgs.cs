using System;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class PinchEventArgs : EventArgs
    {
        public PinchEventArgs(Pinch pinch)
        {
            Pinch = pinch;
        }

        public Pinch Pinch { get; set; }
    }
}