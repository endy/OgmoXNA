using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public abstract class ValueTemplateContent<T> : ValueTemplateContent
    {
        public T Default;

        protected ValueTemplateContent()
            : base()
        {
        }

        protected ValueTemplateContent(XmlNode node)
            : base(node)
        {
        }
    }
}
