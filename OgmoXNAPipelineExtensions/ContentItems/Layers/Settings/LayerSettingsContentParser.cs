using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers.Settings
{
    static class LayerSettingsContentParser
    {
        internal static LayerSettingsContent Parse(XmlNode node)
        {
            LayerSettingsContent content = null;
            switch (node.Name)
            {
                case "grid":
                    content = new GridLayerSettingsContent(node);
                    break;
                case "tiles":
                    content = new TileLayerSettingsContent(node);
                    break;
                case "objects":
                    content = new ObjectLayerSettingsContent(node);
                    break;
            }
            return content;
        }
    }
}
