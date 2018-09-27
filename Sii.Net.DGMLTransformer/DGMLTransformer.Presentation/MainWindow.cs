using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGMLTransformer.Presentation
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            var DgmlSelectorControl = new UserControls.DgmlSelector();
            var DgmlFiltersControl = new UserControls.DgmlFilters();
            var DgmlGeneratorControl = new UserControls.DgmlGenerator();
            DgmlSelectorPanel.Controls.Add(DgmlSelectorControl);
            DgmlFiltersPanel.Controls.Add(DgmlFiltersControl);
            DgmlGeneratorPanel.Controls.Add(DgmlGeneratorControl);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
