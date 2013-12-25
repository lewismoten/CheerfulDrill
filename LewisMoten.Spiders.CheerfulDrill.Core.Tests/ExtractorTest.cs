using System.Collections.Generic;
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
            Assert.That(extractor.Multiple, Is.False);
        }

        [Test]
        public void ExtractionReturnsName()
        {
            var extractor = new Extractor {Name = "Hello World"};
            List<Pinch> pinches = extractor.Extract("Raspberry pie tastes good.");
            Assert.That(pinches, Has.All.Property("Name").EqualTo("Hello World"));
        }

        [Test]
        public void ExtractionWithoutPatternReturnsNothing()
        {
            var extractor = new Extractor {Pattern = string.Empty};
            List<Pinch> pinches = extractor.Extract("an example");
            Assert.That(pinches, Has.All.Property("Value").Empty);
        }

        [Test]
        public void ReturnsDefaultValue()
        {
            var extractor = new Extractor {Pattern = @"\s*(f[^\s]*t)\s*", Group = 2, Default = "not found"};
            List<Pinch> pinches = extractor.Extract("If the first bug is plaid, then I will be impressed.");
            Assert.That(pinches, Has.All.Property("Value").EqualTo("not found"));
        }

        [Test]
        public void ReturnsMultipleMatches()
        {
            var extractor = new Extractor {Pattern = @"\sflo(we|u)r\s", Multiple = true};
            List<Pinch> pinches = extractor.Extract("Every flower has flour petals.");
            Assert.That(pinches, Has.Count.EqualTo(2));
            Assert.That(pinches, Has.Some.Property("Value").EqualTo(" flour "));
            Assert.That(pinches, Has.Some.Property("Value").EqualTo(" flower "));
        }

        [Test]
        public void ReturnsOnlyFirstMatch()
        {
            var extractor = new Extractor {Pattern = @"\sflo(we|u)r\s", Multiple = false};
            List<Pinch> pinches = extractor.Extract("Every flower has flower petals.");
            Assert.That(pinches, Has.Count.EqualTo(1));
            Assert.That(pinches, Has.Some.Property("Value").EqualTo(" flower "));
        }

        [Test]
        public void ReturnsValueOfSpecifiedGroup()
        {
            var extractor = new Extractor {Pattern = @"be\s*([\d]+)\s*", Group = 1};
            List<Pinch> pinches =
                extractor.Extract("If every person had a smile, it would be 64 trillion miles of smiles.");
            Assert.That(pinches, Has.All.Property("Value").EqualTo("64"));
        }

        [Test]
        public void UsesPatternAsRegularExpression()
        {
            var extractor = new Extractor {Pattern = "[cb]at"};
            List<Pinch> pinches = extractor.Extract("The cat had a ball.");
            Assert.That(pinches, Has.All.Property("Value").EqualTo("cat"));
        }
    }
}