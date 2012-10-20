using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public class BooleanValueContent : ValueContent<bool>
    {
        public BooleanValueContent()
            : base()
        {
        }

        public BooleanValueContent(string name, bool value)
            : base()
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
