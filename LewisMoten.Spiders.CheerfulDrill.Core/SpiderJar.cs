﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class SpiderJar
    {
        private static readonly object SynchronizationLock = new object();
        private static readonly SpiderJarProgress Progress = new SpiderJarProgress();

        private readonly List<Extractor> _extractors = new List<Extractor>();
        public string Csv;
        public string Xml { get; set; }

        public string Path { get; set; }
        public string SearchPattern { get; set; }

        public List<Extractor> Extractors
        {
            get { return _extractors; }
        }

        public IProgress<SpiderJarProgress> ProgressReporter
        {
            set { Progress.Reporter = value; }
        }

        public event EventHandler<PinchEventArgs> Pinch;

        protected virtual void OnPinch(Pinch pinch)
        {
            Progress.FoundRecord();

            if (!string.IsNullOrEmpty(Csv))
            {
                lock (SynchronizationLock)
                {
                    if (!File.Exists(Csv))
                    {
                        File.AppendAllLines(Csv, new[] {pinch.Name});
                    }
                    File.AppendAllLines(Csv, new[] {pinch.Value});
                }
            }

            if (!string.IsNullOrEmpty(Xml))
            {
                lock (SynchronizationLock)
                {
                    File.AppendAllText(Xml, pinch.ToString());
                }
            }

            EventHandler<PinchEventArgs> handler = Pinch;
            if (handler != null) handler(this, new PinchEventArgs(pinch));
        }

        public void Shake()
        {
            Shake(CancellationToken.None);
        }

        public void Shake(CancellationToken cancellationToken)
        {
            Progress.Reset();

            if (!string.IsNullOrEmpty(Csv))
            {
                if (File.Exists(Csv))
                {
                    File.Delete(Csv);
                }
            }

            if (!string.IsNullOrEmpty(Xml))
            {
                if (File.Exists(Xml))
                {
                    File.Delete(Xml);
                }
                File.AppendAllText(Xml, "<root>");
            }

            string[] files = Directory.GetFiles(Path, SearchPattern, SearchOption.AllDirectories);

            Progress.InitilizePendingFileCount(files.Length);

            try
            {
                var options = new ParallelOptions
                    {
                        CancellationToken = cancellationToken,
                        MaxDegreeOfParallelism = Environment.ProcessorCount*2
                    };
                Parallel.ForEach(files, options, ProcessFile);
            }
            finally
            {
                if (File.Exists(Xml))
                {
                    File.AppendAllText(Xml, "</root>");
                }
            }
        }

        private void ProcessFile(string file)
        {
            // TODO: Get available spider from a hive factory
            Progress.FileBeingProcessed();
            var spider = new Spider();
            spider.Extractors.AddRange(Extractors);
            spider.Pinch += (sender, e) => OnPinch(e.Pinch);
            spider.Crawl(file);
            Progress.FileHasCompleted();
        }
    }
}