using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers.Settings
{
    public class TileLayerSettingsContent : LayerSettingsContent
    {
        public bool ExportTileIDs;
        public bool ExportTileSize;
        public bool MultipleTilesets;

        public TileLayerSettingsContent()
        {
        }

        public TileLayerSettingsContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["exportTileIDs"] != null)
                this.ExportTileIDs = bool.Parse(node.Attributes["exportTileIDs"].Value);
            if (node.Attributes["exportTileSize"] != null)
                this.ExportTileSize = bool.Parse(node.Attributes["exportTileSize"].Value);
            if (node.Attributes["multipleTilesets"] != null)
                this.MultipleTilesets = bool.Parse(node.Attributes["multipleTilesets"].Value);
        }
    }
}
