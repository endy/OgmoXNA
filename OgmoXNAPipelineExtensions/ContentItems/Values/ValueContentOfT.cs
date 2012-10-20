using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    /// <summary>
    /// A strongly typed <see cref="ValueContent"/> object.
    /// </summary>
    /// <typeparam name="T">The value type the object holds.</typeparam>
    public abstract class ValueContent<T> : ValueContent
    {
        /// <summary>
        /// Creates an instance of <see cref="ValueContent(XmlNode)"/>.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to process.</param>
        protected ValueContent(XmlNode node)
            : base()
        {
            if (node.Attributes["name"] != null)
                this.Name = node.Attributes["name"].Value;
        }

        /// <summary>
        /// The default value of the object.
        /// </summary>
        public T Default { get; set; }

        /// <summary>
        /// The current value of the object.
        /// </summary>
        public T Value { get; set; }
    }
}
