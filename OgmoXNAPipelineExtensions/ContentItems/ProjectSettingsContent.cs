using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;

namespace OgmoXNAPipelineExtensions.ContentItems
{
    public class ProjectSettingsContent
    {
        public int Height;
        public int MaxHeight;
        public int MaxWidth;
        public int MinHeight;
        public int MinWidth;
        public int Width;
        public string WorkingDirectory;

        public ProjectSettingsContent()
        {
            this.Height = 480;
            this.Width = 640;
            this.WorkingDirectory = "gfx";
        }

        public ProjectSettingsContent(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case "defaultHeight":
                        this.Height = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "maxHeight":
                        this.MaxHeight = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "maxWidth":
                        this.MaxWidth = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "minHeight":
                        this.MinHeight = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "minWidth":
                        this.MinWidth = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "defaultWidth":
                        this.Width = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "workingDirectory":
                        this.WorkingDirectory = childNode.InnerText;
                        break;
                }
            }
        }
    }
}
