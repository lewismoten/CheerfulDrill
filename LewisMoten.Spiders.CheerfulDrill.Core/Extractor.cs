using System.Collections.Generic;
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
        public bool Multiple { get; set; }

        public List<Pinch> Extract(string text)
        {
            var pinches = new List<Pinch>();

            if (!string.IsNullOrEmpty(Pattern) && !string.IsNullOrEmpty(text))
            {
                var regex = new Regex(Pattern);
                if (regex.IsMatch(text))
                {
                    if (Multiple)
                    {
                        var matches = regex.Matches(text);
                        foreach (Match match in matches)
                        {
                            Add(pinches, match);
                        }
                    }
                    else
                    {
                        Add(pinches, regex.Match(text));
                    }
                }
            }
            if (pinches.Count == 0)
            {
                AddDefault(pinches);
            }
            return pinches;
        }

        private void AddDefault(ICollection<Pinch> pinches)
        {
            pinches.Add(new Pinch() { Name = Name, Value = Default });

        }

        private void Add(ICollection<Pinch> pinches, Match match)
        {
            pinches.Add(new Pinch() { Name = Name, Value = match.Groups.Count <= Group ? Default : match.Groups[Group].Value });
        }
    }
}