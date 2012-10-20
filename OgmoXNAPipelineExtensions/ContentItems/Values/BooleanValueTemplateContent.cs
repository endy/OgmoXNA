using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public class BooleanValueTemplateContent : ValueTemplateContent<bool>
    {
        public BooleanValueTemplateContent()
        {
        }

        public BooleanValueTemplateContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["default"] != null)
                this.Default = bool.Parse(node.Attributes["default"].Value);
        }
    }
}
