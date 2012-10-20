using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using OgmoXNAPipelineExtensions.ContentItems.Layers.Settings;
using System.IO;
using System.IO.Compression;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers
{
    public class GridLayerContent : LayerContent
    {
        public string RawData;
        public List<Rectangle> RectangleData;

        public GridLayerContent()
        {
        }

        public GridLayerContent(XmlNode node, LevelContent level, GridLayerSettingsContent settings)
            : base(node)
        {
            if (settings.ExportAsObjects)
            {
                this.RectangleData = new List<Rectangle>();
                foreach (XmlNode rectNode in node.SelectNodes("rect"))
                {
                    Rectangle rect = Rectangle.Empty;
                    if (rectNode.Attributes["x"] != null)
                        rect.X = int.Parse(rectNode.Attributes["x"].Value, CultureInfo.InvariantCulture);
                    if (rectNode.Attributes["y"] != null)
                        rect.Y = int.Parse(rectNode.Attributes["y"].Value, CultureInfo.InvariantCulture);
                    if (rectNode.Attributes["w"] != null)
                        rect.Width = int.Parse(rectNode.Attributes["w"].Value, CultureInfo.InvariantCulture);
                    if (rectNode.Attributes["h"] != null)
                        rect.Height = int.Parse(rectNode.Attributes["h"].Value, CultureInfo.InvariantCulture);
                    if (rect != Rectangle.Empty)
                        this.RectangleData.Add(rect);
                }
            }
            else
            {
                // Read in XML as a single un-delimited string value.
                string rawData = string.Join(string.Empty, node.InnerText.Split(new string[] { settings.NewLine }, StringSplitOptions.None));
                // Convert this string to byte data.
                byte[] data = System.Text.Encoding.UTF8.GetBytes(rawData);
                // Convert byte data to base 64 string.
                this.RawData = Convert.ToBase64String(data);
            }
        }
    }
}
