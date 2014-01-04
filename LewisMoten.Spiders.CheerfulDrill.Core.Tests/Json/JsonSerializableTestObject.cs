using System;
using System.Collections.Generic;
using LewisMoten.Spiders.CheerfulDrill.Core.Json;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests.Json
{
    public class JsonSerializableTestObject : IJsonSerializable
    {
        private readonly IList<IJsonSerializable> _items = new List<IJsonSerializable>();
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public bool IsTrue { get; set; }

        public IList<IJsonSerializable> Items
        {
            get { return _items; }
        }

        public void ReadJson(JsonReader reader)
        {
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectOpener();
            writer.Write("name", Name);
            writer.Write("date", Date);
            writer.Write("number", Number);
            writer.Write("istrue", IsTrue);
            writer.WriteArray("items", Items);
            writer.WriteObjectCloser();
        }
    }
}