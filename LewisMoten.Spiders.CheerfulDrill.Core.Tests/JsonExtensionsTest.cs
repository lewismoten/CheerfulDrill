using System.Collections.Generic;
using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests
{
    [TestFixture]
    public class JsonExtensionsTest
    {
        public class JsonTestObject
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        [Test]
        public void ComparesObjects()
        {
            var jsonTestObject1 = new JsonTestObject {Name = "Color", Value = "Blue"};
            var jsonTestObject2 = new JsonTestObject {Name = "Color", Value = "Blue"};
            var jsonTestObject3 = new JsonTestObject {Name = "Color", Value = "Red"};

            IEqualityComparer<JsonTestObject> comparer = jsonTestObject1.GetComparer();

            Assert.That(comparer.GetHashCode(jsonTestObject1), Is.EqualTo(comparer.GetHashCode(jsonTestObject2)));
            Assert.That(comparer.GetHashCode(jsonTestObject1), Is.Not.EqualTo(comparer.GetHashCode(jsonTestObject3)));

            Assert.That(comparer.Equals(jsonTestObject1, jsonTestObject2), Is.True);
            Assert.That(comparer.Equals(jsonTestObject1, jsonTestObject3), Is.False);
        }

        [Test]
        public void CopiesObjectsAndNotReferences()
        {
            Extractor extension = ExtractorTest.GetComplexExtractor();
            Extractor copy = extension.Copy();
            Assert.That(copy, Is.Not.SameAs(extension));
            Assert.That(copy.Bits, Is.Not.SameAs(extension.Bits));
            Assert.That(copy.GetHashCode(), Is.EqualTo(extension.GetHashCode()));
            Assert.That(copy, Is.EqualTo(extension));
        }

        [Test]
        public void DeserializesFromJson()
        {
            const string json = @"{""Value"":""Blue"",""Name"":""Color""}";
            JsonTestObject jsonTestObject = ((JsonTestObject) null).FromJson(json);
            Assert.That(jsonTestObject.Name, Is.EqualTo("Color"));
            Assert.That(jsonTestObject.Value, Is.EqualTo("Blue"));
        }

        [Test]
        public void SerializesToJson()
        {
            var jsonTestObject = new JsonTestObject {Name = "Color", Value = "Blue"};
            string json = jsonTestObject.ToJson();
            Assert.That(json, Is.EqualTo(@"{""Name"":""Color"",""Value"":""Blue""}"));
        }
    }
}