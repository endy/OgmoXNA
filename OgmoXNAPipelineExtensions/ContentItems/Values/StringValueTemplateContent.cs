using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public class StringValueTemplateContent : ValueTemplateContent<string>
    {
        public int MaxChars;

        public StringValueTemplateContent()
        {
        }

        public StringValueTemplateContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["default"] != null)
                this.Default = node.Attributes["default"].Value;
            if (node.Attributes["maxChars"] != null)
                this.MaxChars = int.Parse(node.Attributes["maxChars"].Value, CultureInfo.InvariantCulture);
        }
    }
}
