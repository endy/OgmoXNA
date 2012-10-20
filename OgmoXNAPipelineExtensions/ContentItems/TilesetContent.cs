using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using System.Xml;
using System.Globalization;

namespace OgmoXNAPipelineExtensions.ContentItems
{
    public class TilesetContent
    {
        public string Name;
        public string TextureFile;
        public ExternalReference<TextureContent> TextureReference;
        public int TileHeight;
        public int TileWidth;

        public TilesetContent()
        {
        }

        public TilesetContent(XmlNode node)
        {
            if (node.Attributes["name"] != null)
                this.Name = node.Attributes["name"].Value;
            if (node.Attributes["image"] != null)
                this.TextureFile = node.Attributes["image"].Value;
            if (node.Attributes["tileHeight"] != null)
                this.TileHeight = int.Parse(node.Attributes["tileHeight"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["tileWidth"] != null)
                this.TileWidth = int.Parse(node.Attributes["tileWidth"].Value, CultureInfo.InvariantCulture);
        }
    }
}
