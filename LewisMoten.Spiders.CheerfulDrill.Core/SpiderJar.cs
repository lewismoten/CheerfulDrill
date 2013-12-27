using System;
using System.Collections.Generic;
using System.IO;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class SpiderJar
    {
        private readonly List<Extractor> _extractors = new List<Extractor>();
        public string Csv;
        private int _count;
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
            Console.WriteLine(++_count);
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
                File.AppendAllText(Xml, pinch.ToString());
            }

            EventHandler<PinchEventArgs> handler = Pinch;
            if (handler != null) handler(this, new PinchEventArgs(pinch));
        }

        public void Shake()
        {
            _count = 0;

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
                File.AppendAllText(Xml, "<root>");
            }

            var spider = new Spider();
            spider.Extractors.AddRange(Extractors);
            spider.Pinch += (sender, e) => OnPinch(e.Pinch);
            string[] files = Directory.GetFiles(Path, SearchPattern, SearchOption.AllDirectories);

            try
            {
                foreach (string file in files)
                {
                    spider.Crawl(file);
                }
            }
            finally
            {
                if (File.Exists(Xml))
                {
                    File.AppendAllText(Xml, "</root>");
                }
            }
        }
    }
}