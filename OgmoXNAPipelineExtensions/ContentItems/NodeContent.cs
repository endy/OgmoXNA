using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace OgmoXNAPipelineExtensions.ContentItems
{
    public class NodeContent
    {
        public Vector2 Position;

        public NodeContent()
        {
        }

        public NodeContent(XmlNode node)
        {
            if (node.Attributes["x"] != null)
                this.Position.X = int.Parse(node.Attributes["x"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["y"] != null)
                this.Position.Y = int.Parse(node.Attributes["y"].Value, CultureInfo.InvariantCulture);
        }
    }
}
