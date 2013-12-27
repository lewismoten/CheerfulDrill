using System.Collections.Generic;
using System.Text;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class Pinch
    {
        private readonly List<Pinch> _pinches = new List<Pinch>();

        public Pinch()
        {
            Value = string.Empty;
            Name = string.Empty;
        }

        public string Value { get; set; }
        public string Name { get; set; }

        public List<Pinch> Pinches
        {
            get { return _pinches; }
        }

        public override string ToString()
        {
            if (Value == null)
            {
                return string.Empty;
            }

            if (Pinches.Count == 0)
            {
                return string.Format("<{0}>{1}</{0}>", Encode(Name), Encode(Value));
            }
            var sb = new StringBuilder();
            sb.AppendFormat(@"<{0}>", Name);
            foreach (Pinch pinch in Pinches)
            {
                sb.Append(pinch);
            }
            sb.AppendFormat(@"</{0}>", Name);

            return sb.ToString();
        }

        private string Encode(string text)
        {
            return text.Replace("&", "&amp;");
        }
    }
}