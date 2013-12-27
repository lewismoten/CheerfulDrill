using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests
{
    [TestFixture]
    public class SpiderJarTest
    {
        private static SpiderJar GetSpiderJar(Extractor extractor)
        {
            var jar = new SpiderJar();
            jar.Extractors.Add(extractor);
            jar.Path = "./";
            jar.SearchPattern = "*.html";
            return jar;
        }

        [Test]
        public void ExportCSV()
        {
            var extractor = new Extractor
                {
                    Pattern = "<h1>([^<]*)</h1>",
                    Group = 1,
                    Name = "book-title",
                    Multiple = true
                };

            SpiderJar jar = GetSpiderJar(extractor);
            var pinches = new List<Pinch>();
            jar.Pinch += (sender, e) => pinches.Add(e.Pinch);

            string path = "SpiderJarTest.ExportCSV.csv";
            jar.Csv = path;

            jar.Shake();

            Assert.That(File.Exists(path));

            string[] lines = File.ReadAllLines(path);

            Assert.That(lines.First(), Is.EqualTo("book-title"));
            Assert.That(lines, Has.Member("How to run"));
            Assert.That(lines, Has.Member("How to jog"));
            Assert.That(lines, Has.Member("The joys of crawling"));
        }

        [Test]
        public void ExportXml()
        {
            var extractor = new Extractor
                {
                    Pattern = "<h1>([^<]*)</h1>",
                    Group = 1,
                    Name = "book-title",
                    Multiple = true
                };

            SpiderJar jar = GetSpiderJar(extractor);
            var pinches = new List<Pinch>();
            jar.Pinch += (sender, e) => pinches.Add(e.Pinch);

            string path = "SpiderJarTest.ExportXml.csv";
            jar.Xml = path;

            jar.Shake();

            Assert.That(File.Exists(path));

            var xml = new XmlDocument();
            xml.Load(path);

            XmlNodeList titles = xml.SelectNodes("/root/book-title");
            Assert.That(titles, Is.Not.Null);
            Assert.That(titles, Has.Exactly(1).Property("InnerText").EqualTo("The joys of crawling"));
            Assert.That(titles, Has.Exactly(1).Property("InnerText").EqualTo("How to run"));
            Assert.That(titles, Has.Exactly(1).Property("InnerText").EqualTo("How to jog"));
        }

        [Test]
        public void ParseContents()
        {
            var extractor = new Extractor {Pattern = "title>([^<]*)</title", Group = 1, Name = "title"};
            SpiderJar jar = GetSpiderJar(extractor);

            var pinches = new List<Pinch>();
            jar.Pinch += (sender, e) => pinches.Add(e.Pinch);

            jar.Shake();

            Assert.That(pinches, Has.Some
                                    .Property("Name").EqualTo("title")
                                    .And.Property("Value").EqualTo("Sample Page 1"));
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

            SpiderJar jar = GetSpiderJar(extractor);
            var pinches = new List<Pinch>();
            jar.Pinch += (sender, e) => pinches.Add(e.Pinch);

            jar.Shake();

            Assert.That(pinches, Has.All
                                    .Property("Name").EqualTo("book-title")
                                    .And.Property("Value").EqualTo("How to run")
                                    .Or.Property("Value").EqualTo("How to jog")
                                    .Or.Property("Value").EqualTo("The joys of crawling"));
        }
    }
}