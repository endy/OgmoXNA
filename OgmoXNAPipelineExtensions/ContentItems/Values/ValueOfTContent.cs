using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    public abstract class ValueContent<T> : ValueContent
    {
        public T Value;

        protected ValueContent()
            : base()
        {
        }
    }
}
