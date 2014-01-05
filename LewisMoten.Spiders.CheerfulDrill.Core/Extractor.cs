using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class Extractor : IEquatable<Extractor>
    {
        private static readonly IEqualityComparer<Extractor> ExtractorComparerInstance =
            ((Extractor) null).GetComparer();

        private readonly IList<Extractor> _bits = new List<Extractor>();

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

        public IList<Extractor> Bits
        {
            get { return _bits; }
        }

        public bool Equals(Extractor other)
        {
            return ExtractorComparerInstance.Equals(this, other);
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Extractor) obj);
        }

        public override int GetHashCode()
        {
            return ExtractorComparerInstance.GetHashCode(this);
        }

        public static bool operator ==(Extractor left, Extractor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Extractor left, Extractor right)
        {
            return !Equals(left, right);
        }

        public void AddBits(IEnumerable<Extractor> extractors)
        {
            foreach (Extractor extractor in extractors)
            {
                Bits.Add(extractor);
            }
        }
    }
}