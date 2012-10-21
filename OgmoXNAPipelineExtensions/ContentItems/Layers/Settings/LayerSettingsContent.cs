using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers.Settings
{
    public abstract class LayerSettingsContent
    {
        public Color GridColor;
        public int GridDrawSize;
        public int GridSize;
        public string Name;

        public LayerSettingsContent()
        {
        }

        public LayerSettingsContent(XmlNode node)
        {
            if (node.Attributes["gridColor"] != null)
                this.GridColor = ColorHelper.FromHex(node.Attributes["gridColor"].Value);
            if (node.Attributes["drawGridSize"] != null)
                this.GridDrawSize = int.Parse(node.Attributes["drawGridSize"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["gridSize"] != null)
                this.GridSize = int.Parse(node.Attributes["gridSize"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["name"] != null)
                this.Name = node.Attributes["name"].Value;
        }
    }
}
