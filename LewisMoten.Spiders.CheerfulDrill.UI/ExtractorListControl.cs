using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LewisMoten.Spiders.CheerfulDrill.Core;

namespace LewisMoten.Spiders.CheerfulDrill.UI
{
    public partial class ExtractorListControl : UserControl
    {
        public ExtractorListControl()
        {
            InitializeComponent();
        }

        public void PopulateExtractors(IEnumerable<Extractor> extractors)
        {
            foreach (Extractor extractor in extractors)
            {
                var item = new ListViewItem();
                UpdateExtractorListItem(item, extractor);
                listView1.Items.Add(item);
            }
        }

        public IEnumerable<Extractor> GetExtractors()
        {
            return
                listView1.Items.Cast<ListViewItem>()
                         .Select(i => i.Tag)
                         .Cast<Extractor>()
                         .Select(e => e.Copy());
        }

        private void ListView1DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1)
            {
                return;
            }
            var extractor = listView1.SelectedItems[0].Tag as Extractor;
            if (extractor == null)
            {
                return;
            }
            using (var form = new ExtractorForm())
            {
                form.PopulateFromExtractor(extractor.Copy());
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateExtractorListItem(listView1.SelectedItems[0], form.Extractor);
                }
            }
        }

        private static void UpdateExtractorListItem(ListViewItem item, Extractor extractor)
        {
            item.SubItems.Clear();
            item.Text = extractor.Name;
            item.SubItems.Add(extractor.Default);
            item.SubItems.Add(extractor.Multiple ? "All" : "First");
            item.SubItems.Add(extractor.Pattern);
            item.SubItems.Add(extractor.Group.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(extractor.Bits.Count == 0
                                  ? "None"
                                  : extractor.Bits.Count.ToString(CultureInfo.InvariantCulture));
            item.Tag = extractor.Copy();
        }

        private void AddExtractorButtonClick(object sender, EventArgs e)
        {
            using (var form = new ExtractorForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var item = new ListViewItem();
                    UpdateExtractorListItem(item, form.Extractor);
                    listView1.Items.Add(item);
                }
            }
        }

        private void RemoveButtonClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count < 1)
            {
                return;
            }
            IOrderedEnumerable<int> indicies = listView1.SelectedIndices.Cast<int>().OrderByDescending(i => i);
            foreach (int indicy in indicies)
            {
                listView1.Items.RemoveAt(indicy);
            }
        }
    }
}