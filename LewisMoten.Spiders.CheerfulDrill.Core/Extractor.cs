using System.Text.RegularExpressions;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class Extractor
    {
        public Extractor()
        {
            Pattern = string.Empty;
        }

        public string Pattern { get; set; }
        public int Group { get; set; }

        public string Extract(string text)
        {
            if (string.IsNullOrEmpty(Pattern))
            {
                return string.Empty;
            }
            var regex = new Regex(Pattern);
            return regex.IsMatch(text) ? regex.Match(text).Groups[Group].Value : string.Empty;
        }
    }
}