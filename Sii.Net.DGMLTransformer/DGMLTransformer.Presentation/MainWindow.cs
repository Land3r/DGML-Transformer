using DGMLTransformer.Presentation.UserControls;
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
    /// <summary>
    /// MainWindow class.
    /// Main window of the application.
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The <see cref="DgmlSelector"/> user control.
        /// </summary>
        private DgmlSelector dgmlSelector { get; set; }

        /// <summary>
        /// The <see cref="DgmlFilters"/> user control.
        /// </summary>
        private DgmlFilters dgmlFilters { get; set; }

        /// <summary>
        /// The <see cref="DgmlGenerator"/> user control.
        /// </summary>
        private DgmlGenerator dgmlGenerator { get; set; }

        /// <summary>
        /// Initalizes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.dgmlSelector = new DgmlSelector();
            this.dgmlSelector.Dock = DockStyle.Fill;
            this.dgmlFilters = new DgmlFilters();
            this.dgmlFilters.Dock = DockStyle.Fill;
            this.dgmlGenerator = new DgmlGenerator();
            this.dgmlGenerator.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Event receiver for the OnLoad event.
        /// </summary>
        /// <param name="e">The event payload.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.DgmlSelectorPanel.Controls.Add(this.dgmlSelector);
            this.DgmlFiltersPanel.Controls.Add(this.dgmlFilters);
            this.DgmlGeneratorPanel.Controls.Add(this.dgmlGenerator);
        }
    }
}
