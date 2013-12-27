using System;
using System.Windows.Forms;
using LewisMoten.Spiders.CheerfulDrill.Core;
using LewisMoten.Spiders.CheerfulDrill.UI.Properties;

namespace LewisMoten.Spiders.CheerfulDrill.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void startButton_Click(object sender, EventArgs e)
        {
            var jar = new SpiderJar();


            jar.Path = sourcePathTextBox.Text;
            jar.SearchPattern = sourcePatternTextBox.Text;
            jar.Xml = targetFileTextBox.Text;

            jar.Shake();
        }
    }
}