using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGMLTransformer.Presentation.Events
{
    /// <summary>
    /// Abstract generic class for application events
    /// </summary>
    /// <typeparam name="T">The type of the event (should be an enum).</typeparam>
    /// <typeparam name="U">The type of the payload.</typeparam>
    public abstract class AGenericEventArgs<T, U> : EventArgs
    {
        /// <summary>
        /// Gets or sets the type of the <see cref="GenericEventArgs"/>.
        /// </summary>
        public T Type { get; set; }

        /// <summary>
        /// Gets or sets the payload of the <see cref="GenericEventArgs"/>.
        /// </summary>
        public U Payload { get; set; }

        /// <summary>
        /// Inititializes a new instance of the <see cref="GenericEventArgs"/> class.
        /// </summary>
        /// <param name="type">The type of the event.</param>
        /// <param name="payload">The payload of the event.</param>
        public AGenericEventArgs(T type, U payload)
        {
            this.Type = type;
            this.Payload = payload;
        }
    }
}
