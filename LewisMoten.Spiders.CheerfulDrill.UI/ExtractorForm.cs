using System;
using System.Windows.Forms;
using LewisMoten.Spiders.CheerfulDrill.Core;

namespace LewisMoten.Spiders.CheerfulDrill.UI
{
    public partial class ExtractorForm : Form
    {
        public ExtractorForm()
        {
            InitializeComponent();
            Extractor = new Extractor();
        }

        public Extractor Extractor { get; private set; }

        public void PopulateFromExtractor(Extractor extractor)
        {
            Extractor = extractor.Copy();
            nameTextBox.Text = Extractor.Name;
            defaultValueTextBox.Text = Extractor.Default;
            captureNumericUpDown.Value = Extractor.Group > -1 ? Extractor.Group : 0;
            captureAllRadioButton.Checked = Extractor.Group <= -1;
            captureGroupRadioButton.Checked = Extractor.Group > -1;
            allowMultipleCheckBox.Checked = ! Extractor.Multiple;
            patternTextBox.Text = Extractor.Pattern;
            extractorListControl1.PopulateExtractors(Extractor.Bits);
            Application.DoEvents();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            Extractor.Name = nameTextBox.Text;
            Extractor.Default = defaultValueTextBox.Text;
            Extractor.Group = captureAllRadioButton.Checked ? -1 : (int) captureNumericUpDown.Value;
            Extractor.Multiple = ! allowMultipleCheckBox.Checked;
            Extractor.Pattern = patternTextBox.Text;
            Extractor.Bits.Clear();
            Extractor.AddBits(extractorListControl1.GetExtractors());
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}