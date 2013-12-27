using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests
{
    [TestFixture]
    public class PinchTest
    {
        [Test]
        public void StringFormatWithDepth()
        {
            var pinch = new Pinch {Name = "cookie", Value = "I am totally ignored here"};

            pinch.Pinches.Add(new Pinch {Name = "name", Value = "Chocolate Chip"});
            pinch.Pinches.Add(new Pinch {Name = "ingredient", Value = "chocolate"});

            Assert.That(pinch.ToString(),
                        Is.EqualTo(@"<cookie><name>Chocolate Chip</name><ingredient>chocolate</ingredient></cookie>"));
        }

        [Test]
        public void StringFormatWithNoDepth()
        {
            var pinch = new Pinch {Name = "cookie", Value = "Chocolate"};

            Assert.That(pinch.ToString(), Is.EqualTo(@"<cookie>Chocolate</cookie>"));
        }
    }
}