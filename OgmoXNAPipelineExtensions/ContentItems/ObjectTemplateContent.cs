using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using OgmoXNAPipelineExtensions.ContentItems.Values;

namespace OgmoXNAPipelineExtensions.ContentItems
{
    public class ObjectTemplateContent
    {
        public int Height;
        public bool IsResizableX;
        public bool IsResizableY;
        public bool IsTiled;
        public string Name;
        public Vector2 Origin;
        public Rectangle Source;
        public string TextureFile;
        public ExternalReference<TextureContent> TextureReference;
        public int Width;
        public List<ValueTemplateContent> Values = new List<ValueTemplateContent>();

        public ObjectTemplateContent()
        {
        }

        public ObjectTemplateContent(XmlNode node)
        {
            if (node.Attributes["height"] != null)
                this.Height = int.Parse(node.Attributes["height"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["width"] != null)
                this.Width = int.Parse(node.Attributes["width"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["resizableX"] != null)
                this.IsResizableX = bool.Parse(node.Attributes["resizableX"].Value);
            if (node.Attributes["resizableY"] != null)
                this.IsResizableY = bool.Parse(node.Attributes["resizableY"].Value);
            if (node.Attributes["tile"] != null)
                this.IsTiled = bool.Parse(node.Attributes["tile"].Value);
            if (node.Attributes["name"] != null)
                this.Name = node.Attributes["name"].Value;
            if (node.Attributes["originX"] != null)
                this.Origin.X = int.Parse(node.Attributes["originX"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["originY"] != null)
                this.Origin.Y = int.Parse(node.Attributes["originY"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["imageOffsetX"] != null)
                this.Source.X = int.Parse(node.Attributes["imageOffsetX"].Value, CultureInfo.InvariantCulture);
            else
                this.Source.X = 0;
            if (node.Attributes["imageOffsetY"] != null)
                this.Source.Y = int.Parse(node.Attributes["imageOffsetY"].Value, CultureInfo.InvariantCulture);
            else
                this.Source.Y = 0;
            if (node.Attributes["imageWidth"] != null)
                this.Source.Width = int.Parse(node.Attributes["imageWidth"].Value, CultureInfo.InvariantCulture);
            else
                this.Source.Width = this.Width;
            if (node.Attributes["imageHeight"] != null)
                this.Source.Height = int.Parse(node.Attributes["imageHeight"].Value, CultureInfo.InvariantCulture);
            else
                this.Source.Height = this.Height;
            if (node.Attributes["image"] != null)
                this.TextureFile = node.Attributes["image"].Value;
            // Values
            XmlNode valuesNode = node.SelectSingleNode("values");
            if (valuesNode != null)
            {
                foreach (XmlNode valueNode in valuesNode.SelectNodes("boolean|integer|number|string|text"))
                {
                    ValueTemplateContent valueContent = ValueContentTemplateParser.Parse(valueNode);
                    if (valueContent != null)
                        this.Values.Add(valueContent);
                }
            }
        }
    }
}
