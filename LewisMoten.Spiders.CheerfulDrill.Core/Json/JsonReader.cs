using System.IO;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Json
{
    public class JsonReader
    {
        private readonly TextReader _textReader;

        public JsonReader(TextReader textReader)
        {
            _textReader = textReader;
        }

        public string Read(string name)
        {
            return _textReader.ReadLine();
        }
    }
}