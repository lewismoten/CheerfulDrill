using System.IO;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class Spider
    {
        public string Basket { get; set; }

        public void Crawl(string path)
        {
            if (File.Exists(path))
            {
                Basket = File.ReadAllText(path);
            }
        }
    }
}