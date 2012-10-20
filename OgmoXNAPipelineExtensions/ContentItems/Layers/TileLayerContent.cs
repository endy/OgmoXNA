using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using OgmoXNAPipelineExtensions.ContentItems.Layers.Settings;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers
{
    public class TileLayerContent : LayerContent
    {
        public List<string> Tilesets = new List<string>();
        public List<TileContent> Tiles = new List<TileContent>();
        public int TileHeight;
        public int TileWidth;

        public TileLayerContent()
        {
        }

        public TileLayerContent(XmlNode node, LevelContent level, TileLayerSettingsContent settings)
            : base(node)
        {
            XmlNodeList tileNodes = node.SelectNodes("tile");
            if (!settings.MultipleTilesets)
            {
                // Just one tileset for this layer, so get it and save it.
                if (node.Attributes["set"] != null)
                    this.Tilesets.Add(node.Attributes["set"].Value);
                if (settings.ExportTileSize)
                {
                    if (node.Attributes["tileWidth"] != null)
                        this.TileWidth = int.Parse(node.Attributes["tileWidth"].Value, CultureInfo.InvariantCulture);
                    if (node.Attributes["tileHeight"] != null)
                        this.TileHeight = int.Parse(node.Attributes["tileHeight"].Value, CultureInfo.InvariantCulture);
                }
                else
                {
                    if(this.Tilesets.Count > 0) 
                    {
                        // Extract the tileset so we can get the default tile width/height for the layer.
                        TilesetContent tileset = (from x in level.Project.Tilesets
                                                  where (x.Name == this.Tilesets[0])
                                                  select x).First<TilesetContent>();
                        if (tileset != null)
                        {
                            this.TileWidth = tileset.TileWidth;
                            this.TileHeight = tileset.TileHeight;
                        }
                    }
                }
            }
            else
            {
                // Multiple tilesets for this layer, all saved to each tile.  We want to save these up front, so we 
                // need to extract them all.
                List<XmlNode> nodes = new List<XmlNode>(tileNodes.Count);
                foreach(XmlNode tileNode in tileNodes)
                    nodes.Add(tileNode);
                string[] tilesetNames = (from x in nodes
                                         where (x.Attributes["set"] != null)
                                         select x.Attributes["set"].Value).Distinct<string>().ToArray<string>();
                this.Tilesets.AddRange(tilesetNames);
            }
            foreach (XmlNode tileNode in tileNodes)
                this.Tiles.Add(new TileContent(tileNode, this, settings));
        }
    }
}
