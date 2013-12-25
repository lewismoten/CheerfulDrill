using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests
{
    [TestFixture]
    public class SpiderJarTest
    {
        [Test]
        public void ParseContents()
        {
            var extractor = new Extractor {Pattern = "title>([^<]*)</title", Group = 1, Name = "title"};
            var jar = new SpiderJar();
            jar.Extractors.Add(extractor);
            jar.Path = "./";
            jar.SearchPattern = "Sample1.html";
            jar.Shake();
            IEnumerable<string> titles = jar.Pinches.Where(p => p.Name == "title").Select(p => p.Value);
            Assert.That(titles, Has.Member("Sample Page 1"));
        }

        [Test]
        public void ParseMultipleContentsFromEachPage()
        {
            var extractor = new Extractor
                {
                    Pattern = "<h1>([^<]*)</h1>",
                    Group = 1,
                    Name = "book-title",
                    Multiple = true
                };
            var jar = new SpiderJar();
            jar.Extractors.Add(extractor);
            jar.Path = "./";
            jar.SearchPattern = "*.html";
            jar.Shake();
            IEnumerable<string> titles = jar.Pinches.Where(p => p.Name == "book-title").Select(p => p.Value);
            Assert.That(titles, Has.Member("How to run"));
            Assert.That(titles, Has.Member("How to jog"));
            Assert.That(titles, Has.Member("The joys of crawling"));
        }
    }
}