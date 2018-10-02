namespace DGMLTransformer.Services.Dgml
{
    using DgmlLib;
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
    }
}
