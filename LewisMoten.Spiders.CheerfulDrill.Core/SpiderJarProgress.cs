using System;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public class SpiderJarProgress
    {
        private static readonly object SynchronizationLock = new object();

        public int FilesProcessing { get; private set; }
        public int FilesPending { get; private set; }
        public int FilesCompleted { get; private set; }
        public int RecordsFound { get; private set; }

        public IProgress<SpiderJarProgress> Reporter { get; set; }

        internal void FileBeingProcessed()
        {
            Report(() =>
                {
                    FilesPending--;
                    FilesProcessing++;
                });
        }

        internal void FileHasCompleted()
        {
            Report(() =>
                {
                    FilesProcessing--;
                    FilesCompleted++;
                });
        }

        internal void InitilizePendingFileCount(int count)
        {
            Report(() =>
                {
                    FilesPending = count;
                    FilesProcessing = 0;
                    FilesCompleted = 0;
                    RecordsFound = 0;
                });
        }

        internal void Reset()
        {
            Report(() =>
                {
                    FilesPending = 0;
                    FilesCompleted = 0;
                    FilesProcessing = 0;
                    RecordsFound = 0;
                });
        }

        internal void FoundRecord()
        {
            Report(() => { RecordsFound++; });
        }

        private void Report(Action action)
        {
            if (Reporter == null) return;
            lock (SynchronizationLock)
            {
                action();
            }
            Reporter.Report(this);
        }
    }
}