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
        /// Event handler for when the user clicks on save file.
        /// </summary>
        public event EventHandler<EventArgs> SaveFileventHandler;

        /// <summary>
        /// Envent handler for when the user clicks on view file.
        /// </summary>
        public event EventHandler<EventArgs> ViewFileEventHandler;

        public DgmlGenerator()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.SaveFileventHandler?.Invoke(this, e);
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            this.ViewFileEventHandler?.Invoke(this, e);
        }
    }
}
