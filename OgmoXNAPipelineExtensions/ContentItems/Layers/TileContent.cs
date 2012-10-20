using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using OgmoXNAPipelineExtensions.ContentItems.Layers.Settings;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers
{
    public class TileContent
    {
        public int Height;
        public Vector2 Position = Vector2.Zero;
        public Vector2 TextureOffset;
        public int SourceIndex;
        public string TilesetName;
        public int Width;

        public TileContent()
        {
        }

        public TileContent(XmlNode node, TileLayerContent layer, TileLayerSettingsContent settings)
        {
            if (!settings.MultipleTilesets && !settings.ExportTileSize)
            {
                this.Height = layer.TileHeight;
                this.Width = layer.TileWidth;
            }
            else if(settings.MultipleTilesets || settings.ExportTileSize) 
            {
                if (node.Attributes["th"] != null)
                    this.Height = int.Parse(node.Attributes["th"].Value, CultureInfo.InvariantCulture);
                if (node.Attributes["tw"] != null)
                    this.Width = int.Parse(node.Attributes["tw"].Value, CultureInfo.InvariantCulture);
            }
            if (node.Attributes["x"] != null)
                this.Position.X = int.Parse(node.Attributes["x"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["y"] != null)
                this.Position.Y = int.Parse(node.Attributes["y"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["tx"] != null)
                this.TextureOffset.X = int.Parse(node.Attributes["tx"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["ty"] != null)
                this.TextureOffset.Y = int.Parse(node.Attributes["ty"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["id"] != null)
                this.SourceIndex = int.Parse(node.Attributes["id"].Value, CultureInfo.InvariantCulture);
            if (settings.MultipleTilesets)
            {
                if (node.Attributes["set"] != null)
                    this.TilesetName = node.Attributes["set"].Value;
            }
            else
                this.TilesetName = layer.Tilesets[0];
        }
    }
}
