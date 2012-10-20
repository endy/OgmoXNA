using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public class IntegerValueContent : ValueContent<int>
    {
        public IntegerValueContent()
            : base()
        {
        }

        public IntegerValueContent(string name, int value)
            : base()
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
