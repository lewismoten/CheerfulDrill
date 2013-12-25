using System.Collections.Generic;
using System.IO;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class SpiderJar
    {
        private readonly List<Extractor> _extractors = new List<Extractor>();
        private readonly List<Pinch> _pinches = new List<Pinch>();

        public string Path { get; set; }
        public string SearchPattern { get; set; }

        public List<Extractor> Extractors
        {
            get { return _extractors; }
        }

        public List<Pinch> Pinches
        {
            get { return _pinches; }
        }

        public void Shake()
        {
            var spider = new Spider();
            string[] files = Directory.GetFiles(Path, SearchPattern, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                spider.Crawl(file);
                foreach (Extractor extractor in Extractors)
                {
                    Pinches.AddRange(extractor.Extract(spider.Basket));
                }
            }
        }
    }
}