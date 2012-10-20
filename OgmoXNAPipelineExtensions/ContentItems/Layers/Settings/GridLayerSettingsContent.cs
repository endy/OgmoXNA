using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers.Settings
{
    public class GridLayerSettingsContent : LayerSettingsContent
    {
        public bool ExportAsObjects;
        public string NewLine;

        public GridLayerSettingsContent()
        {
        }

        public GridLayerSettingsContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["exportAsObjects"] != null)
                this.ExportAsObjects = bool.Parse(node.Attributes["exportAsObjects"].Value);
            if (node.Attributes["newLine"] != null)
                this.NewLine = node.Attributes["newLine"].Value;
            this.NewLine = this.NewLine ?? "\n";                
        }
    }
}
