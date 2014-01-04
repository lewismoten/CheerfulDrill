using System;
using System.Collections.Generic;
using System.IO;
using LewisMoten.Spiders.CheerfulDrill.Core.Json;
using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests.Json
{
    [TestFixture]
    public class JsonWriterTest : IDisposable
    {
        [SetUp]
        public void SetUp()
        {
            _textWriter = new StringWriter();
            _jsonWriter = new JsonWriter(_textWriter);
        }

        private const string ObjectNotOpened = "The object has not been opened.";

        private TextWriter _textWriter;
        private JsonWriter _jsonWriter;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_textWriter != null)
            {
                _textWriter.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [Test]
        public void FailsToCloseObjectThatIsNotOpened()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => _jsonWriter.WriteObjectCloser());
            Assert.That(ex.Message, Is.EqualTo(ObjectNotOpened));
        }

        [Test]
        public void FailsToWriteWhenObjectNotOpened()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => _jsonWriter.Write("name", "value"));
            Assert.That(ex.Message, Is.EqualTo(ObjectNotOpened));
        }

        [Test]
        public void WritesArrays()
        {
            var items = new List<IJsonSerializable>
                {
                    new JsonSerializableTestObject {Name = "item1"},
                    new JsonSerializableTestObject {Name = "item2"}
                };

            _jsonWriter.WriteObjectOpener();
            _jsonWriter.WriteArray("myField1", items);

            Assert.That(_textWriter.ToString(), Is.
                                                    StringContaining("myField1").And.
                                                    StringContaining("[").And.
                                                    StringContaining("item1").And.
                                                    StringContaining(",").And.
                                                    StringContaining("item2").And.
                                                    StringContaining("]")
                );
        }

        [Test]
        public void WritesBooleanValue()
        {
            _jsonWriter.WriteObjectOpener();
            _jsonWriter.Write("myField1", true);
            _jsonWriter.Write("myField2", false);
            Assert.That(_textWriter.ToString(), Is.
                                                    StringContaining("myField1").And.
                                                    StringContaining("True").And.
                                                    StringContaining("myField2").And.
                                                    StringContaining("False"));
        }

        [Test]
        public void WritesCommaSeparatedProperties()
        {
            _jsonWriter.WriteObjectOpener();
            _jsonWriter.Write("myField1", "myValue1");
            Assert.That(_textWriter.ToString(), Is.
                                                    Not.StringContaining(",").And.
                                                    StringContaining("myField1"));

            _jsonWriter.Write("myField2", "myValue2");
            Assert.That(_textWriter.ToString(), Is.
                                                    StringContaining("myField1").And.
                                                    StringContaining(",").And.
                                                    StringContaining("myField2"));
        }

        [Test]
        public void WritesComplexFormatting()
        {
            var item = new JsonSerializableTestObject
                {
                    Name = "parent",
                    Number = 42,
                    Date = new DateTime(2014, 1, 4, 3, 59, 32, 8, DateTimeKind.Utc),
                    IsTrue = true
                };

            item.Items.Add(new JsonSerializableTestObject
                {
                    Name = "eldest",
                    Date = new DateTime(DateTime.MinValue.Ticks, DateTimeKind.Utc),
                    Number = int.MinValue,
                    IsTrue = true
                });

            item.Items.Add(new JsonSerializableTestObject
                {
                    Name = "youngest",
                    Date = new DateTime(DateTime.MaxValue.Ticks, DateTimeKind.Utc),
                    Number = int.MaxValue,
                    IsTrue = false
                });

            ((JsonSerializableTestObject) item.Items[0]).Items.Add(new JsonSerializableTestObject
                {
                    Name = "grandchild",
                    Date = new DateTime(DateTime.MaxValue.Ticks, DateTimeKind.Utc),
                    Number = int.MaxValue,
                    IsTrue = true
                });

            item.WriteJson(_jsonWriter);

            Console.Out.WriteLine(_textWriter);
            Assert.That(_textWriter.ToString(), Is.EqualTo(
                @"{
    'name': 'parent',
    'date': 'Sat Jan 04 2014 03:59:32.008 UTC',
    'number': '42',
    'istrue': 'True',
    'items': [{
            'name': 'eldest',
            'date': 'Mon Jan 01 0001 00:00:00.000 UTC',
            'number': '-2147483648',
            'istrue': 'True',
            'items': [{
                    'name': 'grandchild',
                    'date': 'Fri Dec 31 9999 23:59:59.999 UTC',
                    'number': '2147483647',
                    'istrue': 'True',
                    'items': []
                }]
        },
        {
            'name': 'youngest',
            'date': 'Fri Dec 31 9999 23:59:59.999 UTC',
            'number': '2147483647',
            'istrue': 'False',
            'items': []
        }]
}"));
        }

        [Test]
        public void WritesDateValue()
        {
            var date = new DateTime(1975, 5, 28, 3, 18, 32, 912, DateTimeKind.Utc);
            _jsonWriter.WriteObjectOpener();
            _jsonWriter.Write("myField1", DateTime.MinValue);
            _jsonWriter.Write("myField2", DateTime.MaxValue);
            _jsonWriter.Write("myField3", date);
            Assert.That(_textWriter.ToString(), Is.
                                                    StringContaining("myField1").And.
                                                    StringContaining(JsonEncoder.Encode(DateTime.MinValue)).And.
                                                    StringContaining("myField2").And.
                                                    StringContaining(JsonEncoder.Encode(DateTime.MaxValue)).And.
                                                    StringContaining("myField3").And.
                                                    StringContaining(JsonEncoder.Encode(date)));
        }

        [Test]
        public void WritesIntegerValue()
        {
            _jsonWriter.WriteObjectOpener();
            _jsonWriter.Write("myField1", int.MinValue);
            _jsonWriter.Write("myField2", int.MaxValue);
            _jsonWriter.Write("myField3", 0);
            Assert.That(_textWriter.ToString(), Is.
                                                    StringContaining("myField1").And.
                                                    StringContaining(int.MinValue.ToString("D")).And.
                                                    StringContaining("myField2").And.
                                                    StringContaining(int.MaxValue.ToString("D")).And.
                                                    StringContaining("myField3").And.
                                                    StringContaining(0.ToString("D")));
        }

        [Test]
        public void WritesObjectPrefix()
        {
            _jsonWriter.WriteObjectOpener();
            Assert.That(_textWriter.ToString(), Is.EqualTo("{"));
        }

        [Test]
        public void WritesObjectSuffix()
        {
            _jsonWriter.WriteObjectOpener();
            _jsonWriter.WriteObjectCloser();
            Assert.That(_textWriter.ToString(), Is.StringEnding("}"));
        }

        [Test]
        public void WritesPropertyName()
        {
            _jsonWriter.WriteObjectOpener();
            _jsonWriter.Write("myField", "myValue");
            Assert.That(_textWriter.ToString(), Is.StringContaining("myField"));
        }

        [Test]
        public void WritesStringValue()
        {
            _jsonWriter.WriteObjectOpener();
            _jsonWriter.Write("myField", "myValue");
            Assert.That(_textWriter.ToString(), Is.StringContaining("myField").And.StringContaining("myValue"));
        }
    }
}