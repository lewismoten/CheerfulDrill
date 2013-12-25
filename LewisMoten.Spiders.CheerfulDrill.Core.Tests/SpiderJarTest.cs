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
            jar.SearchPattern = "*.html";
            jar.Shake();
            IEnumerable<string> titles = jar.Pinches.Where(p => p.Name == "title").Select(p => p.Value);
            Assert.That(titles, Has.Member("Sample Page 1"));
            Assert.That(titles, Has.Member("Sample Page 2"));
        }
    }
}