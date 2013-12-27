using System;
using System.Collections.Generic;
using System.IO;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class SpiderJar
    {
        private readonly List<Extractor> _extractors = new List<Extractor>();
        public string Csv;
        public string Xml { get; set; }

        public string Path { get; set; }
        public string SearchPattern { get; set; }

        public List<Extractor> Extractors
        {
            get { return _extractors; }
        }

        public event EventHandler<PinchEventArgs> Pinch;

        protected virtual void OnPinch(Pinch pinch)
        {
            if (!string.IsNullOrEmpty(Csv))
            {
                if (!File.Exists(Csv))
                {
                    File.AppendAllLines(Csv, new[] {pinch.Name});
                }
                File.AppendAllLines(Csv, new[] {pinch.Value});
            }

            if (!string.IsNullOrEmpty(Xml))
            {
                if (!File.Exists(Xml))
                {
                    File.AppendAllText(Xml, "<root>");
                }
                File.AppendAllText(Xml, pinch.ToString());
            }

            EventHandler<PinchEventArgs> handler = Pinch;
            if (handler != null) handler(this, new PinchEventArgs(pinch));
        }

        public void Shake()
        {
            if (!string.IsNullOrEmpty(Csv))
            {
                if (File.Exists(Csv))
                {
                    File.Delete(Csv);
                }
            }

            if (!string.IsNullOrEmpty(Xml))
            {
                if (File.Exists(Xml))
                {
                    File.Delete(Xml);
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
            if (File.Exists(Xml))
            {
                File.AppendAllText(Xml, "</root>");
            }
        }
    }
}