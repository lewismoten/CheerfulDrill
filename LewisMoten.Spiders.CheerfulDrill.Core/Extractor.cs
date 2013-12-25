using System.Text.RegularExpressions;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class Extractor
    {
        public Extractor()
        {
            Pattern = string.Empty;
            Name = string.Empty;
            Default = string.Empty;
        }

        public string Name { get; set; }
        public string Pattern { get; set; }
        public int Group { get; set; }
        public string Default { get; set; }

        public Pinch Extract(string text)
        {
            var pinch = new Pinch {Name = Name};

            if (string.IsNullOrEmpty(Pattern))
            {
                return pinch;
            }
            var regex = new Regex(Pattern);
            if (regex.IsMatch(text))
            {
                Match match = regex.Match(text);
                pinch.Value = match.Groups.Count <= Group ? Default : match.Groups[Group].Value;
            }
            else
            {
                pinch.Value = Default;
            }
            return pinch;
        }
    }
}