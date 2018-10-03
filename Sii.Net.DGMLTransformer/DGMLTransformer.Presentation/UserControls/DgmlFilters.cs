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
                return DgmlCategoryCheckedItem.Select(p => new DgmlCategory() { Id = p.Name, Label = p.Text }).ToList();//this.DgmlCategoryCheckedListView.CheckedItems.Cast<DgmlCategory>().ToList();
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
        /// Fill the check list with category.
        /// </summary>
        private void FillCheckedListView(IList<DgmlCategory> dgmlCategories)
        {
            IList<ListViewItem> dgmlCategoryList = dgmlCategories.OrderBy(p => p.Label).Select(p => new ListViewItem() {Name = p.Id, Text = p.Label }).ToList();
            foreach (ListViewItem category in dgmlCategoryList)
            {
                this.DgmlCategoryCheckedListView.Items.Add(category);
            }
        }

        /// <summary>
        /// Empty the collection of filters.
        /// </summary>
        private void EmptyListView()
        {
            this.DgmlCategoryCheckedListView.Items.Clear();
        }

        /// <summary>
        /// Event receiver for the <see cref="DgmlFileEventArgs"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event payload.</param>
        public void OnDgmlFileSelected(object sender, DgmlFileEventArgs e)
        {
            if (e.Type == DgmlFileEventEnum.Selected)
            {
                this.EmptyListView();
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
    }
}
