using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using OgmoXNAPipelineExtensions.ContentItems.Layers.Settings;
using OgmoXNAPipelineExtensions.ContentItems.Values;

namespace OgmoXNAPipelineExtensions.ContentItems
{
    public class ProjectContent
    {
        public List<LayerSettingsContent> LayerSettings = new List<LayerSettingsContent>();
        public string Name;
        public List<ObjectTemplateContent> Objects = new List<ObjectTemplateContent>();
        public ProjectSettingsContent Settings;
        public List<TilesetContent> Tilesets = new List<TilesetContent>();
        public List<ValueTemplateContent> Values = new List<ValueTemplateContent>();

        public ProjectContent()
        {
        }

        public ProjectContent(XmlDocument document)
        {
            XmlNode projectNode = document["project"];
            // Name
            XmlNode nameNode = projectNode.SelectSingleNode("name");
            if (nameNode != null)
                this.Name = nameNode.InnerText;
            // Settings
            XmlNode settingsNode = projectNode.SelectSingleNode("settings");
            if (settingsNode != null)
                this.Settings = new ProjectSettingsContent(settingsNode);
            else
                this.Settings = new ProjectSettingsContent();
            // Values
            XmlNode valuesNode = projectNode.SelectSingleNode("values");
            if (valuesNode != null)
            {
                foreach (XmlNode valueNode in valuesNode.ChildNodes)
                {
                    ValueTemplateContent valueContent = ValueContentTemplateParser.Parse(valueNode);
                    if (valueContent != null)
                        this.Values.Add(valueContent);
                }
            }
            // Tilesets
            XmlNode tilesetsNode = projectNode.SelectSingleNode("tilesets");
            if (tilesetsNode != null)
            {
                foreach (XmlNode childNode in tilesetsNode)
                    this.Tilesets.Add(new TilesetContent(childNode));
            }
            // Objects
            XmlNode objectsNode = projectNode.SelectSingleNode("objects");
            if (objectsNode != null)
            {
                foreach (XmlNode childNode in objectsNode.SelectNodes("object|folder/object"))
                    this.Objects.Add(new ObjectTemplateContent(childNode));
            }   
            // Layer Settings
            XmlNode layerSettingsNode = projectNode.SelectSingleNode("layers");
            if (layerSettingsNode != null)
            {
                foreach (XmlNode childNode in layerSettingsNode.ChildNodes)
                {
                    LayerSettingsContent layerSettingsContent = LayerSettingsContentParser.Parse(childNode);
                    if (layerSettingsContent != null)
                        this.LayerSettings.Add(layerSettingsContent);
                }
            }
        }
    }
}
