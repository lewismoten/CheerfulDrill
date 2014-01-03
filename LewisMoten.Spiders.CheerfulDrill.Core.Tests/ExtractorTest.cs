using System.Collections.Generic;
using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests
{
    [TestFixture]
    public class ExtractorTest
    {
        [Test]
        public void ClonesWithADeepCopy()
        {
            var extractor = new Extractor
                {
                    Name = "name",
                    Pattern = "Mr.( [^ ]*){2:3}",
                    Default = "Unknown",
                    Group = 1,
                    Multiple = true,
                };
            extractor.Bits.Add(
                new Extractor
                    {
                        Name = "First",
                        Pattern = "^ ([^ ]*)",
                        Default = "",
                        Group = 1,
                        Multiple = false
                    });
            extractor.Bits.Add(
                new Extractor
                    {
                        Name = "Last",
                        Pattern = " ([^ ]*)$",
                        Default = "",
                        Group = 1,
                        Multiple = false
                    });

            var clone = extractor.Clone() as Extractor;

            if (clone == null)
            {
                Assert.Fail();
            }

            Assert.That(clone, Is.Not.SameAs(extractor));
            Assert.That(clone.Name, Is.EqualTo(extractor.Name));
            Assert.That(clone.Pattern, Is.EqualTo(extractor.Pattern));
            Assert.That(clone.Default, Is.EqualTo(extractor.Default));
            Assert.That(clone.Group, Is.EqualTo(extractor.Group));
            Assert.That(clone.Multiple, Is.EqualTo(extractor.Multiple));
            Assert.That(clone.Bits, Is.Not.SameAs(extractor.Bits));
            Assert.That(clone.Bits.Count, Is.EqualTo(extractor.Bits.Count));
            Assert.That(clone.Bits.Count, Is.EqualTo(2));

            for (int i = 0; i < extractor.Bits.Count; i++)
            {
                Assert.That(clone.Bits[i], Is.Not.Null);
                Assert.That(clone.Bits[i], Is.Not.SameAs(extractor.Bits[i]));

                Assert.That(clone.Bits[i].Name, Is.EqualTo(extractor.Bits[i].Name));
                Assert.That(clone.Bits[i].Pattern, Is.EqualTo(extractor.Bits[i].Pattern));
                Assert.That(clone.Bits[i].Default, Is.EqualTo(extractor.Bits[i].Default));
                Assert.That(clone.Bits[i].Group, Is.EqualTo(extractor.Bits[i].Group));
                Assert.That(clone.Bits[i].Multiple, Is.EqualTo(extractor.Bits[i].Multiple));
                Assert.That(clone.Bits[i].Bits, Is.Not.SameAs(extractor.Bits[i].Bits));
                Assert.That(clone.Bits[i].Bits.Count, Is.EqualTo(extractor.Bits[i].Bits.Count));
            }
        }

        [Test]
        public void DefaultValues()
        {
            var extractor = new Extractor();
            Assert.That(extractor.Pattern, Is.Empty);
            Assert.That(extractor.Name, Is.Empty);
            Assert.That(extractor.Default, Is.Null);
            Assert.That(extractor.Group, Is.EqualTo(0));
            Assert.That(extractor.Multiple, Is.False);
        }

        [Test]
        public void ExtractionReturnsHeirachricalData()
        {
            var extractor = new Extractor {Name = "Person", Pattern = @"<person[\s\S]*?/person>", Multiple = true};
            extractor.Bits.Add(new Extractor {Name = "Id", Pattern = @"id=""([^""]*)""", Group = 1});
            extractor.Bits.Add(new Extractor {Name = "FullName", Pattern = @">([^<]*)<", Group = 1});

            List<Pinch> pinches =
                extractor.Extract(@"<people><person id=""1"">Jim</person><person id=""2"">Joe</person></people>");

            Assert.That(pinches, Has.Count.EqualTo(2));
            Assert.That(pinches, Has.All.Property("Name").EqualTo("Person"));

            List<Pinch> first = pinches[0].Pinches;
            Assert.That(first, Has.Count.EqualTo(2));
            Assert.That(first, Has.Exactly(1).Property("Name").EqualTo("Id").And.Property("Value").EqualTo("1"));
            Assert.That(first, Has.Exactly(1).Property("Name").EqualTo("FullName").And.Property("Value").EqualTo("Jim"));

            List<Pinch> second = pinches[1].Pinches;
            Assert.That(second, Has.Count.EqualTo(2));
            Assert.That(second, Has.Exactly(1).Property("Name").EqualTo("Id").And.Property("Value").EqualTo("2"));
            Assert.That(second, Has.Exactly(1).Property("Name").EqualTo("FullName").And.Property("Value").EqualTo("Joe"));
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
            var extractor = new Extractor {Pattern = string.Empty, Default = string.Empty};
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