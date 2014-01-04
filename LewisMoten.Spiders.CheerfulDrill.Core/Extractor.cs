using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LewisMoten.Spiders.CheerfulDrill.Core.Json;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class Extractor : ICloneable, IJsonSerializable
    {
        private readonly List<Extractor> _bits = new List<Extractor>();

        public Extractor()
        {
            Pattern = string.Empty;
            Name = string.Empty;
        }

        public string Name { get; set; }
        public string Pattern { get; set; }
        public int Group { get; set; }
        public string Default { get; set; }
        public bool Multiple { get; set; }

        public List<Extractor> Bits
        {
            get { return _bits; }
        }

        public object Clone()
        {
            var extractor = new Extractor
                {
                    Default = Default,
                    Group = Group,
                    Multiple = Multiple,
                    Name = Name,
                    Pattern = Pattern
                };

            foreach (Extractor bit in Bits)
            {
                extractor.Bits.Add((Extractor) bit.Clone());
            }

            return extractor;
        }

        public void ReadJson(JsonReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectOpener();
            writer.Write("name", Name);
            writer.Write("pattern", Pattern);
            writer.Write("group", Group);
            writer.Write("default", Default);
            writer.Write("multiple", Multiple);
            writer.WriteArray("bits", Bits);
            writer.WriteObjectCloser();
        }

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
                        MatchCollection matches = regex.Matches(text);
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
            pinches.Add(new Pinch {Name = Name, Value = Default});
        }

        private void Add(ICollection<Pinch> pinches, Match match)
        {
            string value = match.Groups.Count <= Group ? Default : match.Groups[Group].Value;
            var pinch = new Pinch {Name = Name, Value = value};
            pinches.Add(pinch);
            if (Bits.Count == 0) return;
            foreach (Extractor extractor in Bits)
            {
                pinch.Pinches.AddRange(extractor.Extract(value));
            }
        }
    }
}