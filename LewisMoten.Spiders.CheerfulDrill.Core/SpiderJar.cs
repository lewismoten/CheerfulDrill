using System;
using System.Collections.Generic;
using System.IO;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class SpiderJar
    {
        private readonly List<Extractor> _extractors = new List<Extractor>();
        public string CSV;

        public string Path { get; set; }
        public string SearchPattern { get; set; }

        public List<Extractor> Extractors
        {
            get { return _extractors; }
        }

        public event EventHandler<PinchEventArgs> Pinch;

        protected virtual void OnPinch(Pinch pinch)
        {
            if (!string.IsNullOrEmpty(CSV))
            {
                if (!File.Exists(CSV))
                {
                    File.AppendAllLines(CSV, new[] {pinch.Name});
                }
                File.AppendAllLines(CSV, new[] {pinch.Value});
            }

            EventHandler<PinchEventArgs> handler = Pinch;
            if (handler != null) handler(this, new PinchEventArgs(pinch));
        }

        public void Shake()
        {
            if (!string.IsNullOrEmpty(CSV))
            {
                if (File.Exists(CSV))
                {
                    File.Delete(CSV);
                }
            }
            var spider = new Spider();
            spider.Extractors.AddRange(Extractors);
            spider.Pinch += (sender, e) => OnPinch(e.Pinch);
            string[] files = Directory.GetFiles(Path, SearchPattern, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                spider.Crawl(file);
            }
        }
    }
}