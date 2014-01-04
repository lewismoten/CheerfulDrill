using System;
using System.Collections.Generic;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Json
{
    public class DepthDelimiter
    {
        private const string DepthTooShallow = "The delimter has not been started.";
        private const string DepthTooDeep = "The delimiter is full.";
        private readonly Action _addDelimiter;
        private readonly List<int> _first = new List<int>();
        private readonly int _maxDepth;

        public DepthDelimiter(Action addDelimiter) : this(addDelimiter, int.MaxValue)
        {
        }

        public DepthDelimiter(Action addDelimiter, int maxDepth)
        {
            if (addDelimiter == null)
            {
                throw new ArgumentNullException("addDelimiter");
            }
            if (maxDepth < 1)
            {
                throw new ArgumentOutOfRangeException("maxDepth");
            }
            _addDelimiter = addDelimiter;
            _maxDepth = maxDepth;
        }

        public bool CanDelimit
        {
            get { return Depth != 0; }
        }

        public int Depth
        {
            get { return _first.Count; }
        }

        public int Counted
        {
            get { return _first[0]; }
        }

        public void StartNew()
        {
            if (_first.Count >= _maxDepth)
            {
                throw new InvalidOperationException(DepthTooDeep);
            }
            _first.Insert(0, 0);
        }

        public void Completed()
        {
            if (!CanDelimit)
            {
                throw new InvalidOperationException(DepthTooShallow);
            }
            _first.RemoveAt(0);
        }

        public void Delimit()
        {
            if (!CanDelimit)
            {
                throw new InvalidOperationException(DepthTooShallow);
            }
            if (Counted != 0)
            {
                _addDelimiter();
            }
            _first[0]++;
        }
    }
}