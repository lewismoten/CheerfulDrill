using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Json
{
    public class JsonWriter
    {
        private const string ObjectNotOpened = "The object has not been opened.";
        private const string ObjectPrefix = "{";
        private const string ObjectSuffix = "}";
        private const string BeginArray = "[";
        private const string CompleteArray = "]";
        private const string Delimiter = ",";
        private const string PropertyPrefix = "'";
        private const string PropertySuffix = "': ";
        private const string ValuePrefix = "'";
        private const string ValueSuffix = "'";
        private const string Indent = "    ";

        private readonly DepthDelimiter _delimiter;
        private readonly TextWriter _writer;

        public JsonWriter(TextWriter writer)
        {
            _writer = writer;
            _delimiter = new DepthDelimiter(() => _writer.Write(Delimiter));
        }

        public void Write(string name, bool value)
        {
            Write(name, value.ToString());
        }

        public void Write(string name, int value)
        {
            Write(name, value.ToString("D"));
        }

        public void Write(string name, DateTime value)
        {
            Write(name, JsonEncoder.Encode(value));
        }

        public void Write(string name, string value)
        {
            WritePropertyName(name);
            _writer.Write(ValuePrefix);
            _writer.Write(JsonEncoder.Encode(value));
            _writer.Write(ValueSuffix);
        }

        public void WriteObjectOpener()
        {
            _delimiter.StartNew();
            _writer.Write(ObjectPrefix);
        }

        public void WriteObjectCloser()
        {
            if (!_delimiter.CanDelimit)
            {
                throw new InvalidOperationException(ObjectNotOpened);
            }
            _delimiter.Completed();
            PrepareNextLine();
            _writer.Write(ObjectSuffix);
        }

        public void WriteArray<T>(string name, IEnumerable<T> items) where T : class, IJsonSerializable
        {
            WritePropertyName(name);
            _writer.Write(BeginArray);

            _delimiter.StartNew();
            foreach (T item in items)
            {
                _delimiter.Delimit();
                if (_delimiter.Counted != 1)
                {
                    PrepareNextLine();
                }

                item.WriteJson(this);
            }

            _delimiter.Completed();

            _writer.Write(CompleteArray);
        }

        private void WritePropertyName(string name)
        {
            if (!_delimiter.CanDelimit)
            {
                throw new InvalidOperationException(ObjectNotOpened);
            }
            _delimiter.Delimit();
            PrepareNextLine();
            _writer.Write(PropertyPrefix);
            _writer.Write(JsonEncoder.Encode(name));
            _writer.Write(PropertySuffix);
        }

        private void PrepareNextLine()
        {
            _writer.Write(Environment.NewLine);
            _writer.Write(string.Concat(Enumerable.Repeat(Indent, _delimiter.Depth)));
        }
    }
}