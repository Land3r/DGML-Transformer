using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGMLTransformer.Presentation.Models;
using DGMLTransformer.Presentation.Events;

namespace DGMLTransformer.Presentation.UserControls
{
    /// <summary>
    /// DgmlSelector user control.
    /// Used to display a way for the user to select his dgml file.
    /// </summary>
    public partial class DgmlSelector : UserControl
    {
        /// <summary>
        /// Event handler for when the user selects a dgml file.
        /// </summary>
        public event EventHandler<DgmlFileEventArgs> DgmlFileHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DgmlSelector"/> class.
        /// </summary>
        public DgmlSelector()
        {
            InitializeComponent();

            DgmlFileHandler += new EventHandler<DgmlFileEventArgs>(this.OnDgmlFileSelected);
        }

        /// <summary>
        /// Event receiver for when the user clicks on the 'Select file' button
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event payload.</param>
        private void DgmlSelectorButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Dgml Files|*.dgml";
            openFileDialog.Title = "Select a Dgml File";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DgmlFile dgmlFile = new DgmlFile();
                dgmlFile.FileName = openFileDialog.SafeFileName;
                dgmlFile.FilePath = openFileDialog.FileName;

                this.DgmlFileHandler?.Invoke(this, new DgmlFileEventArgs(DgmlFileEventEnum.Selected, dgmlFile));
            }
        }

        /// <summary>
        /// Event receiver for the DgmlFileHandler event.
        /// </summary>
        /// <param name="sender">the event sender.</param>
        /// <param name="e">The event payload.</param>
        private void OnDgmlFileSelected(object sender, DgmlFileEventArgs e)
        {
            if (e.Type == DgmlFileEventEnum.Selected)
            {
                SelectedDgmlName.Text = e.DgmlFile.FileName;
            }
            else if (e.Type == DgmlFileEventEnum.Loaded)
            {
            }
        }
    }
}
