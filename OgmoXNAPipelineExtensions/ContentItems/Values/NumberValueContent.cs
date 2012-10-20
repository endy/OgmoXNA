using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public class NumberValueContent : ValueContent<float>
    {
        public NumberValueContent()
            : base()
        {
        }

        public NumberValueContent(string name, float value)
            : base()
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
