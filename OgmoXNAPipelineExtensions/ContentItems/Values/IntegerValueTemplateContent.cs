using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public class IntegerValueTemplateContent : ValueTemplateContent<int>
    {
        public int Max;
        public int Min;

        public IntegerValueTemplateContent()
        {
        }

        public IntegerValueTemplateContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["default"] != null)
                this.Default = int.Parse(node.Attributes["default"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["max"] != null)
                this.Max = int.Parse(node.Attributes["max"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["min"] != null)
                this.Min = int.Parse(node.Attributes["min"].Value, CultureInfo.InvariantCulture);
        }
    }
}
