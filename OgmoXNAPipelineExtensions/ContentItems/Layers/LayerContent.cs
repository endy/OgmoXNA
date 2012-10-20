using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using OgmoXNAPipelineExtensions.ContentItems.Layers.Settings;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers
{
    public abstract class LayerContent
    {
        public string Name;

        public LayerContent()
        {
        }

        public LayerContent(XmlNode node)
        {
            this.Name = node.Name;
        }
    }
}
