using System.IO;
using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests
{
    [TestFixture]
    public class SpiderTest
    {
        private string _sample1;

        [TestFixtureSetUp]
        public void BeforeTheFirstTest()
        {
            _sample1 = File.ReadAllText("Sample1.html");
        }

        [Test]
        public void FileContentsPlacedInBasket()
        {
            string path = "Sample1.html";
            var spider = new Spider();
            spider.Crawl(path);
            Assert.That(spider.Basket, Is.EqualTo(_sample1));
        }

        [Test]
        public void NothingInBasketIfFileNotFound()
        {
            const string path = "Sample-Not-Exists.html";
            var spider = new Spider();
            spider.Crawl(path);
            Assert.That(spider.Basket, Is.Null.Or.Empty);
        }

        [Test]
        public void SupportsAbsolutePath()
        {
            string path = Path.GetFullPath("Sample1.html");
            var spider = new Spider();
            spider.Crawl(path);
            Assert.That(spider.Basket, Is.EqualTo(_sample1));
        }
    }
}