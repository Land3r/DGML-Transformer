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
using DgmlLib;
using DGMLTransformer.Presentation.Events;

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
        private void FillCheckedListView(IList<DgmlCategory> dgmlCategories)
        {
            foreach (DgmlCategory category in dgmlCategories)
            {
                this.DgmlCategoryCheckedListBox.Items.Add(category);
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
