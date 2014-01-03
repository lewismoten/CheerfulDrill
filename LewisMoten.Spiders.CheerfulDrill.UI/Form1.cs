using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LewisMoten.Spiders.CheerfulDrill.Core;
using LewisMoten.Spiders.CheerfulDrill.UI.Properties;

namespace LewisMoten.Spiders.CheerfulDrill.UI
{
    public partial class Form1 : Form
    {
        private static int _filesPending;
        private static int _filesProcessing;
        private static int _filesCompleted;
        private static int _recordsFound;
        private readonly Progress<SpiderJarProgress> _spiderJarProgress = new Progress<SpiderJarProgress>();
        private CancellationTokenSource _cancellationTokenSource;
        private Task _task;


        public Form1()
        {
            InitializeComponent();
            _spiderJarProgress.ProgressChanged += SpiderJarProgressChanged;
        }

        private void SpiderJarProgressChanged(object sender, SpiderJarProgress e)
        {
            _filesPending = e.FilesPending;
            _filesProcessing = e.FilesProcessing;
            _filesCompleted = e.FilesCompleted;
            _recordsFound = e.RecordsFound;
        }

        private void ChooseSourceButtonClick(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = sourcePathTextBox.Text;
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.Description = Resources.ChooseSourcePath;

            DialogResult answer = folderBrowserDialog1.ShowDialog(this);
            if (answer == DialogResult.OK)
            {
                sourcePathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ChooseTargetButtonClick(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Filter = Resources.TargetFileFilter;
            saveFileDialog1.InitialDirectory = targetFileTextBox.Text;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Title = Resources.SaveDataAs;
            DialogResult answer = saveFileDialog1.ShowDialog(this);
            if (answer == DialogResult.OK)
            {
                targetFileTextBox.Text = saveFileDialog1.FileName;
            }
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            Application.DoEvents();

            _cancellationTokenSource = new CancellationTokenSource();
            _task = Task.Factory.StartNew(() => Shake(_spiderJarProgress), _cancellationTokenSource.Token);
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null) _cancellationTokenSource.Cancel();
            stopButton.Enabled = false;
        }

        private void Shake(IProgress<SpiderJarProgress> progress)
        {
            var jar = new SpiderJar {ProgressReporter = progress};
            jar.Extractors.AddRange(extractorListControl1.GetExtractors());
            jar.Path = sourcePathTextBox.Text;
            jar.SearchPattern = sourcePatternTextBox.Text;
            jar.Xml = targetFileTextBox.Text;

            jar.Shake(_cancellationTokenSource.Token);
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            if (_task != null)
            {
                taskStatusLabel.Text = _task.Status.ToString();
                if (_task.IsCompleted)
                {
                    startButton.Enabled = true;
                    stopButton.Enabled = false;
                    _task.Dispose();
                    _task = null;
                }
            }

            decimal max = _filesCompleted + _filesPending + _filesProcessing + 0.0m;
            if (max == 0)
            {
                progressBar1.Value = 0;
            }
            else if (_filesCompleted >= max)
            {
                progressBar1.Value = 100;
            }
            else
            {
                progressBar1.Value = (int) ((_filesCompleted/max)*100);
            }

            label5.Text = string.Format(@"Records Found: {0}", _recordsFound);

            Application.DoEvents();
        }
    }
}