using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public class StringValueContent : ValueContent<string>
    {
        public StringValueContent()
            : base()
        {
        }

        public StringValueContent(string name, string value)
            : base()
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
