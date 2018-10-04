namespace DGMLTransformer.Services.Dgml
{
    using DgmlLib;
    using DGMLTransformer.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Service for manipulating DGMLfiles.
    /// </summary>
    public class DgmlService : IDgmlService
    {
        /// <summary>
        /// Initalizes a new instance of the <see cref="DgmlService"/> class.
        /// </summary>
        public DgmlService()
        {
        }

        /// <summary>
        /// Gets a new <see cref="DgmlDoc"/> from the file provided.
        /// </summary>
        /// <param name="filepath">The fullpath to the document.</param>
        /// <returns>The <see cref="DgmlDoc"/> corresponding to the file.</returns>
        public DgmlDoc GetFromFile(string filepath)
        {
            DgmlDoc document = new DgmlDoc();
            document.LoadFromFile(filepath);
            return document;
        }

        /// <summary>
        /// Saves the <see cref="DgmlDoc"/> on the current file.
        /// </summary>
        /// <param name="dgmlDoc">The <see cref="DgmlDoc"/> to save.</param>
        public void SaveFile(DgmlDoc dgmlDoc, bool backup = false)
        {
            dgmlDoc.SaveOnCurrentFile(backup);
        }

        /// <summary>
        /// Hides all the categories of the <see cref="DgmlDoc"/>.
        /// </summary>
        /// <param name="doc">The <see cref="DgmlDoc"/> where to hide all categories.</param>
        /// <returns>The modified <see cref="DgmlDoc"/>.</returns>
        public DgmlDoc HideAllCategories(DgmlDoc doc)
        {
            doc.HideAllCategories();
            return doc;
        }

        /// <summary>
        /// Hides a list of categories of the <see cref="DgmlDoc"/>.
        /// </summary>
        /// <param name="doc">The <see cref="DgmlDoc"/> where to hide the categories.</param>
        /// <param name="dgmlCategories">The list of <see cref="DgmlCategory"/> to hide.</param>
        /// <returns>The modified <see cref="DgmlDoc"/>.</returns>
        public DgmlDoc HideCategories(DgmlDoc doc, IList<DgmlCategory> dgmlCategories)
        {
            foreach (DgmlCategory dgmlCategory in dgmlCategories)
            {
                this.HideCategory(doc, dgmlCategory);
            }
            return doc;
        }

        /// <summary>
        /// Hide a specific category of the <see cref="DgmlDoc"/>.
        /// </summary>
        /// <param name="doc">The <see cref="DgmlDoc"/> where to hide the category.</param>
        /// <param name="dgmlCategory">The <see cref="DgmlCategory"/> to hide.</param>
        /// <returns>The modified <see cref="DgmlDoc"/>.</returns>
        public DgmlDoc HideCategory(DgmlDoc doc, DgmlCategory dgmlCategory)
        {
            Category category = new Category() { Id = dgmlCategory.Id, Label = dgmlCategory.Label };
            doc.HideCategory(category);
            return doc;
        }

        /// <summary>
        /// Shows all the categories of the <see cref="DgmlDoc"/>.
        /// </summary>
        /// <param name="doc">The <see cref="DgmlDoc"/> where to show all categories.</param>
        /// <returns>The modified <see cref="DgmlDoc"/>.</returns>
        public DgmlDoc ShowAllCategories(DgmlDoc doc)
        {
            doc.ShowAllCategories();
            return doc;
        }

        /// <summary>
        /// Shows a list of categories of the <see cref="DgmlDoc"/>.
        /// </summary>
        /// <param name="doc">The <see cref="DgmlDoc"/> where to show the categories.</param>
        /// <param name="dgmlCategories">The list of <see cref="DgmlCategory"/> to show.</param>
        /// <returns>The modified <see cref="DgmlDoc"/>.</returns>
        public DgmlDoc ShowCategories(DgmlDoc doc, IList<DgmlCategory> dgmlCategories)
        {
            foreach (DgmlCategory dgmlCategory in dgmlCategories)
            {
                this.ShowCategory(doc, dgmlCategory);
            }
            return doc;
        }

        /// <summary>
        /// Show a specific category of the <see cref="DgmlDoc"/>.
        /// </summary>
        /// <param name="doc">The <see cref="DgmlDoc"/> where to show the category.</param>
        /// <param name="dgmlCategory">The <see cref="DgmlCategory"/> to show.</param>
        /// <returns>The modified <see cref="DgmlDoc"/>.</returns>
        public DgmlDoc ShowCategory(DgmlDoc doc, DgmlCategory dgmlCategory)
        {
            Category category = new Category() { Id = dgmlCategory.Id, Label = dgmlCategory.Label };
            doc.ShowCategory(category);
            return doc;
        }
    }
}
