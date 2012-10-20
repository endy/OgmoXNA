using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers.Settings
{
    public class ObjectLayerSettingsContent : LayerSettingsContent
    {
        public ObjectLayerSettingsContent()
        {
        }

        public ObjectLayerSettingsContent(XmlNode node)
            : base(node)
        {
        }
    }
}
