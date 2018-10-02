using DGMLTransformer.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGMLTransformer.Presentation.Events
{
    /// <summary>
    /// DgmlFileEventArgs class.
    /// Used for events related to the <see cref="DgmlFile"/>
    /// </summary>
    public class DgmlFileEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the type of the <see cref="DgmlFileEventArgs"/>.
        /// </summary>
        public DgmlFileEventEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DgmlFile"/> of the <see cref="DgmlFileEventArgs"/>.
        /// </summary>
        public DgmlFile DgmlFile { get; set; }

        /// <summary>
        /// Inititializes a new instance of the <see cref="DgmlFileEventArgs"/> class.
        /// </summary>
        /// <param name="type">The <see cref="DgmlFileEventEnum"/> of the event.</param>
        /// <param name="dgmlFile">The <see cref="DgmlFile"/> of the event.</param>
        public DgmlFileEventArgs(DgmlFileEventEnum type, DgmlFile dgmlFile)
        {
            this.Type = type;
            this.DgmlFile = dgmlFile;
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
