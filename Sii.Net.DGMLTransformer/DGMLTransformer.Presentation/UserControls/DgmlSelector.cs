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

namespace DGMLTransformer.Presentation.UserControls
{
    public partial class DgmlSelector : UserControl
    {
        public Dgml MyDgml = new Dgml();

        public DgmlSelector()
        {
            InitializeComponent();
        }

        private void DgmlSelectorButton_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Dgml.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Dgml Files|*.dgml";
            openFileDialog1.Title = "Select a Dgml File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyDgml.FileName = openFileDialog1.SafeFileName;
                MyDgml.FilePath = openFileDialog1.FileName;

                SelectedDgmlName.Text = MyDgml.FileName;
                // Assign the dgml in the Stream to the Form's Cursor property.  
                //this.dgml = new Dgml(openFileDialog1.OpenFile());
            }
        }
    }
}
