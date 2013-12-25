using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests
{
    [TestFixture]
    public class ExtractorTest
    {
        [Test]
        public void DefaultValues()
        {
            var extractor = new Extractor();
            Assert.That(extractor.Pattern, Is.Empty);
        }

        [Test]
        public void ExtractionWithoutPatternReturnsNothing()
        {
            var extractor = new Extractor {Pattern = string.Empty};
            string value = extractor.Extract("an example");
            Assert.That(value, Is.Empty);
        }

        [Test]
        public void ReturnsOnlyFirstMatch()
        {
            var extractor = new Extractor {Pattern = @"\sflower\s"};
            string value = extractor.Extract("Every flower has flower petals.");
            Assert.That(value, Is.EqualTo(" flower "));
        }

        [Test]
        public void ReturnsValueOfSpecifiedGroup()
        {
            var extractor = new Extractor {Pattern = @"be\s*([\d]+)\s*", Group = 1};
            string value = extractor.Extract("If every person had a smile, it would be 64 trillion miles of smiles");
            Assert.That(value, Is.EqualTo("64"));
        }

        [Test]
        public void UsesPatternAsRegularExpression()
        {
            var extractor = new Extractor {Pattern = "[cb]at"};
            string value = extractor.Extract("The cat had a ball.");
            Assert.That(value, Is.EqualTo("cat"));
        }
    }
}