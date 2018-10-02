using DgmlLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGMLTransformer.Presentation.Events
{
    /// <summary>
    /// DgmlDocEventArgs class.
    /// Used for events related to the <see cref="DgmlDoc"/>
    /// </summary>
    public class DgmlDocEventArgs : AGenericEventArgs<DgmlDocEventEnum, DgmlDoc>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DgmlDocEventArgs"/> class.
        /// </summary>
        /// <param name="type">The type of event.</param>
        /// <param name="payload">The payload of event.</param>
        public DgmlDocEventArgs(DgmlDocEventEnum type, DgmlDoc payload) : base(type, payload)
        {
        }
    }

    /// <summary>
    /// DgmlDocEvent enum.
    /// Used to represent the kind of event available on <see cref="DgmlDoc"/>.
    /// </summary>
    public enum DgmlDocEventEnum
    {
        /// <summary>
        /// Triggered once the <see cref="DgmlDoc"/> is loaded.
        /// </summary>
        Loaded
    }
}
