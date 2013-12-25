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

        public string Extract(string text)
        {
            if (string.IsNullOrEmpty(Pattern))
            {
                return string.Empty;
            }
            var regex = new Regex(Pattern);
            if (regex.IsMatch(text))
            {
                var match = regex.Match(text);
                return match.Groups.Count <= Group ? Default : match.Groups[Group].Value;
            }
            return Default;
        }
    }
}