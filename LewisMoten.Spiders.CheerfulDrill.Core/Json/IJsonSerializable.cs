namespace LewisMoten.Spiders.CheerfulDrill.Core.Json
{
    public interface IJsonSerializable
    {
        void ReadJson(JsonReader reader);
        void WriteJson(JsonWriter writer);
    }
}