namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class Pinch
    {
        public Pinch()
        {
            Value = string.Empty;
            Name = string.Empty;
        }

        public string Value { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}={1}", Name, Value);
        }
    }
}