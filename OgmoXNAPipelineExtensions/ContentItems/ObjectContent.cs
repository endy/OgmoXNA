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
    public class ObjectContent
    {
        public int Height;
        public bool IsTiled;
        public string Name;
        public List<NodeContent> Nodes = new List<NodeContent>();
        public Vector2 Origin;
        public Vector2 Position;
        public float Rotation;
        public Rectangle Source;
        public ExternalReference<TextureContent> TextureReference;
        public List<ValueContent> Values = new List<ValueContent>();
        public int Width;

        public ObjectContent()
        {
        }

        public ObjectContent(XmlNode node, ObjectTemplateContent template)
        {
            this.Name = node.Name;
            this.TextureReference = template.TextureReference;
            this.IsTiled = template.IsTiled;
            this.Origin = template.Origin;
            this.Source = template.Source;
            if (node.Attributes["height"] != null)
                this.Height = int.Parse(node.Attributes["height"].Value, CultureInfo.InvariantCulture);
            else
                this.Height = template.Height;
            if (node.Attributes["x"] != null)
                this.Position.X = int.Parse(node.Attributes["x"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["y"] != null)
                this.Position.Y = int.Parse(node.Attributes["y"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["width"] != null)
                this.Width = int.Parse(node.Attributes["width"].Value, CultureInfo.InvariantCulture);
            else
                this.Width = template.Width;
            if (node.Attributes["angle"] != null)
                this.Rotation = float.Parse(node.Attributes["angle"].Value, CultureInfo.InvariantCulture);
            if (this.IsTiled)
            {
                this.Source.Width = this.Width;
                this.Source.Height = this.Height;
            }
        }
    }
}
