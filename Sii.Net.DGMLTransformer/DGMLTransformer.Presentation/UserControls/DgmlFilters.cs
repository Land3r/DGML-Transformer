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
    public partial class DgmlFilters : UserControl
    {
        public DgmlFilters()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Fill the check list with category
        /// </summary>
        private void FillCheckedListView() {
            //TODO : A brancher sur la récupération de la liste des categories !
            IEnumerable<DgmlCategory> categoryList = new List<DgmlCategory>();

            foreach (var category in categoryList)
            {
                this.DgmlCategoryCheckedListBox.Items.Add(category);
            }
            DgmlCategoryCheckedListBox.Refresh();
        }

        private void DgmlCategoryCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = DgmlCategoryCheckedListBox.CheckedItems;
        }

        private void DgmlCategoryCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedCategory = DgmlCategoryCheckedListBox.CheckedItems;
        }
    }
}
