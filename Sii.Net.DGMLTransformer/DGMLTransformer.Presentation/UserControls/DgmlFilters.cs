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
using DgmlApi;

namespace DGMLTransformer.Presentation.UserControls
{
    public partial class DgmlFilters : UserControl
    {
        public IList<DgmlCategory> DgmlCategories
        {
            get
            {
                return this.DgmlCategoryCheckedListBox.CheckedItems.Cast<DgmlCategory>().ToList();
            }
        }

        public DgmlFilters()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Fill the check list with category
        /// </summary>
        public void FillCheckedListView(IList<DgmlCategory> dgmlCategories)
        {
            foreach (DgmlCategory category in dgmlCategories)
            {
                this.DgmlCategoryCheckedListBox.Items.Add(category);
            }
        }
    }
}
