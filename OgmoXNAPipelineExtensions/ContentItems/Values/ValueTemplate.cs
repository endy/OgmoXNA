using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public abstract class ValueTemplateContent
    {
        public string Name;

        protected ValueTemplateContent()
        {
        }

        protected ValueTemplateContent(XmlNode node)
        {
            if(node.Attributes["name"] != null)
                this.Name = node.Attributes["name"].Value;
        }
    }
}
