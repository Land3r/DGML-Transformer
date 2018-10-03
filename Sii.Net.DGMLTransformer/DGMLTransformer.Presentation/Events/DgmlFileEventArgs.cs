using DGMLTransformer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGMLTransformer.Presentation.Events
{
    /// <summary>
    /// DgmlFileEventArgs class.
    /// Used for events related to the <see cref="Payload"/>
    /// </summary>
    public class DgmlFileEventArgs : AGenericEventArgs<DgmlFileEventEnum, DgmlFile>
    {
        /// <summary>
        /// Inititializes a new instance of the <see cref="DgmlFileEventArgs"/> class.
        /// </summary>
        /// <param name="type">The <see cref="DgmlFileEventEnum"/> of the event.</param>
        /// <param name="dgmlFile">The <see cref="Payload"/> of the event.</param>
        public DgmlFileEventArgs(DgmlFileEventEnum type, DgmlFile dgmlFile) : base(type, dgmlFile)
        {
        }
    }

    /// <summary>
    /// DgmlFileEvent Enum.
    /// Represents the different kinds of events that can be raised.
    /// </summary>
    public enum DgmlFileEventEnum
    {
        /// <summary>
        /// Event emitted when the user selects a Dgml file.
        /// </summary>
        Selected,

        /// <summary>
        /// Event emitted when the dgml file is loaded.
        /// </summary>
        Loaded
    }
}
