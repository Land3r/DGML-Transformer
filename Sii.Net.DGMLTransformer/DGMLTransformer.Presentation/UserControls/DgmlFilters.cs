using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DgmlLib;
using DGMLTransformer.Presentation.Events;
using DGMLTransformer.Domain;

namespace DGMLTransformer.Presentation.UserControls
{
    public partial class DgmlFilters : UserControl
    {
        public IList<DgmlCategory> DgmlCategories
        {
            get
            {
                return DgmlCategoryCheckedItem.Select(p => new DgmlCategory() { Id = p.Name, Label = p.Text }).ToList();
            }
        }

        public IList<ListViewItem> DgmlCategoryCheckedItem
        {
            get
            {
                return this.DgmlCategoryCheckedListView.CheckedItems.Cast<ListViewItem>().ToList();
            }
        }

        public DgmlFilters()
        {
            InitializeComponent();
            DgmlCategoryCheckedListView.CheckBoxes = true;
        }
        /// <summary>
        /// Fill the check list with category
        /// </summary>
        private void FillCheckedListView(IList<DgmlCategory> dgmlCategories)
        {
            this.DgmlCategoryCheckedListView.Items.Clear();
            IList<ListViewItem> dgmlCategoryList = dgmlCategories.OrderBy(p => p.Label).Select(p => new ListViewItem() {Name = p.Id, Text = p.Label }).ToList();
            foreach (ListViewItem category in dgmlCategoryList)
            {
                this.DgmlCategoryCheckedListView.Items.Add(category);
            }
        }

        /// <summary>
        /// Event receiver for the <see cref="DgmlDocEventArgs"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event payload.</param>
        public void OnDgmlDocLoaded(object sender, DgmlDocEventArgs e)
        {
            if (e.Type == DgmlDocEventEnum.Loaded)
            {
                IList<DgmlCategory> dgmlCategories = e.Payload.Categories.Select(p => new DgmlCategory() { Id = p.Id, Label = p.Label }).ToList();
                this.FillCheckedListView(dgmlCategories);
            }
        }

        /// <summary>
        /// Check or uncheck all items in DgmlCategoryCheckedListView
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event payload</param>
        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (DgmlCategoryCheckedListView != null)
            {
                if (CheckAll.Checked)
                {
                    for (int i = 0; i < DgmlCategoryCheckedListView.Items.Count; i++)
                    {
                        DgmlCategoryCheckedListView.Items[i].Checked = true;
                    }
                }
                else {
                    for (int i = 0; i < DgmlCategoryCheckedListView.Items.Count; i++)
                    {
                        DgmlCategoryCheckedListView.Items[i].Checked = false;
                    }
                }                
            }
        }
    }
}
