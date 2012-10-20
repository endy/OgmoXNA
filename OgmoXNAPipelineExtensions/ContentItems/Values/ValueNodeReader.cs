using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    /// <summary>
    /// Xml node reader for <see cref="ValueContent"/> objects.
    /// </summary>
    static class ValueNodeReader
    {
        /// <summary>
        /// Reads a <see cref="XmlNode"/> for an Ogmo Editor value.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to read.</param>
        /// <returns>Returns a <see cref="ValueContent"/> object of the appropriate type if valid; 
        /// otherwise, <c>null</c>.</returns>
        internal static ValueContent Read(XmlNode node)
        {
            ValueContent valueContent = null;
            switch (node.Name)
            {
                case "boolean":
                    valueContent = new BooleanValueContent(node);
                    break;
                case "integer":
                    valueContent = new IntegerValueContent(node);
                    break;
                case "number":
                    valueContent = new NumberValueContent(node);
                    break;
                case "string":
                // Fallthrough.
                case "text":
                    valueContent = new StringValueContent(node);
                    break;
            }
            return valueContent;
        }
    }
}
