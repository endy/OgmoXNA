using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public class NumberValueTemplateContent : ValueTemplateContent<float>
    {
        public float Max;
        public float Min;

        public NumberValueTemplateContent()
        {
        }

        public NumberValueTemplateContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["default"] != null)
                this.Default = float.Parse(node.Attributes["default"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["max"] != null)
                this.Max = float.Parse(node.Attributes["max"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["min"] != null)
                this.Min = float.Parse(node.Attributes["min"].Value, CultureInfo.InvariantCulture);
        }
    }
}
