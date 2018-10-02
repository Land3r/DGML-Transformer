using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGMLTransformer.Presentation.UserControls
{
    public partial class DgmlGenerator : UserControl
    {
        /// <summary>
        /// Event handler for when the user selects a dgml file.
        /// </summary>
        public event EventHandler<EventArgs> EventHandler;

        public DgmlGenerator()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.EventHandler?.Invoke(this, e);
        }
    }
}
