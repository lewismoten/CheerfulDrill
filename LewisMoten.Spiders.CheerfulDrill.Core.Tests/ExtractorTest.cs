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
            Assert.That(extractor.Name, Is.Empty);
            Assert.That(extractor.Default, Is.Empty);
            Assert.That(extractor.Group, Is.EqualTo(0));
        }

        [Test]
        public void ExtractionReturnsName()
        {
            var extractor = new Extractor {Name = "Hello World"};
            Pinch pinch = extractor.Extract("Raspberry pie tastes good.");
            Assert.That(pinch.Name, Is.EqualTo("Hello World"));
        }

        [Test]
        public void ExtractionWithoutPatternReturnsNothing()
        {
            var extractor = new Extractor {Pattern = string.Empty};
            Pinch pinch = extractor.Extract("an example");
            Assert.That(pinch.Value, Is.Empty);
        }

        [Test]
        public void ReturnsDefaultValue()
        {
            var extractor = new Extractor {Pattern = @"\s*(f[^\s]*t)\s*", Group = 2, Default = "not found"};
            Pinch pinch = extractor.Extract("If the first bug is plaid, then I will be impressed.");
            Assert.That(pinch.Value, Is.EqualTo("not found"));
        }

        [Test]
        public void ReturnsOnlyFirstMatch()
        {
            var extractor = new Extractor {Pattern = @"\sflower\s"};
            Pinch pinch = extractor.Extract("Every flower has flower petals.");
            Assert.That(pinch.Value, Is.EqualTo(" flower "));
        }

        [Test]
        public void ReturnsValueOfSpecifiedGroup()
        {
            var extractor = new Extractor {Pattern = @"be\s*([\d]+)\s*", Group = 1};
            Pinch pinch = extractor.Extract("If every person had a smile, it would be 64 trillion miles of smiles.");
            Assert.That(pinch.Value, Is.EqualTo("64"));
        }

        [Test]
        public void UsesPatternAsRegularExpression()
        {
            var extractor = new Extractor {Pattern = "[cb]at"};
            Pinch pinch = extractor.Extract("The cat had a ball.");
            Assert.That(pinch.Value, Is.EqualTo("cat"));
        }
    }
}