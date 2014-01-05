using System;
using System.Collections.Generic;
using System.IO;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class Spider
    {
        private readonly List<Extractor> _extractors = new List<Extractor>();
        public string Basket { get; set; }

        public List<Extractor> Extractors
        {
            get { return _extractors; }
        }

        public event EventHandler<PinchEventArgs> Pinch;

        protected virtual void OnPinch(PinchEventArgs e)
        {
            EventHandler<PinchEventArgs> handler = Pinch;
            if (handler != null) handler(this, e);
        }

        public void Crawl(string path)
        {
            if (File.Exists(path))
            {
                Basket = File.ReadAllText(path);
                foreach (Extractor extractor in Extractors)
                {
                    List<Pinch> pinches = extractor.Extract(Basket);
                    foreach (Pinch pinch in pinches)
                    {
                        OnPinch(new PinchEventArgs(pinch));
                    }
                }
            }
        }
    }
}