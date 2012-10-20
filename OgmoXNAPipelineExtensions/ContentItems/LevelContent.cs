using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline;
using OgmoXNAPipelineExtensions.ContentItems.Values;
using System.Reflection;
using OgmoXNAPipelineExtensions.ContentItems.Layers.Settings;
using OgmoXNAPipelineExtensions.ContentItems.Layers;

namespace OgmoXNAPipelineExtensions.ContentItems
{
    public class LevelContent
    {
        public int Height;
        public List<LayerContent> Layers = new List<LayerContent>();
        public ProjectContent Project;
        public ExternalReference<ProjectContent> ProjectReference;
        public List<ValueContent> Values = new List<ValueContent>();
        public int Width;

        public LevelContent()
        {
        }

        public LevelContent(ProjectContent project, XmlDocument document)
        {
            this.Project = project;
            XmlNode levelNode = document["level"];
            // Level values/attributes
            foreach (ValueTemplateContent value in project.Values)
            {
                XmlNode attribute = null;
                if ((attribute = levelNode.Attributes[value.Name]) != null)
                {
                    if (value is BooleanValueTemplateContent)
                        this.Values.Add(new BooleanValueContent(value.Name, bool.Parse(attribute.Value)));
                    else if (value is IntegerValueTemplateContent)
                        this.Values.Add(new IntegerValueContent(value.Name, 
                            int.Parse(attribute.Value, CultureInfo.InvariantCulture)));
                    else if (value is NumberValueTemplateContent)
                        this.Values.Add(new NumberValueContent(value.Name, 
                            float.Parse(attribute.Value, CultureInfo.InvariantCulture)));
                    else if (value is StringValueTemplateContent)
                        this.Values.Add(new StringValueContent(value.Name, attribute.Value));
                }
            }
            // Height
            this.Height = int.Parse(levelNode.SelectSingleNode("height").InnerText, CultureInfo.InvariantCulture);
            // Width
            this.Width = int.Parse(levelNode.SelectSingleNode("width").InnerText, CultureInfo.InvariantCulture);
            // Layers
            // Here we'll construct an XPath query of all possible layer names so we can just extract the nodes all 
            // at once.
            string[] layerNames = (from x in project.LayerSettings select x.Name).ToArray<string>();
            string layerXPath = string.Join("|", layerNames);
            foreach (XmlNode layerNode in levelNode.SelectNodes(layerXPath))
            {
                // Attempt to extract the settings for this layer.
                LayerSettingsContent[] s = (from x in project.LayerSettings
                                            where x.Name.Equals(layerNode.Name)
                                            select x).ToArray<LayerSettingsContent>();
                if (!(s.Length > 0))
                    continue;
                LayerSettingsContent layerSettings = s[0];
                // We have a grid layer.
                if (layerSettings is GridLayerSettingsContent)
                {
                    GridLayerSettingsContent settings = layerSettings as GridLayerSettingsContent;
                    GridLayerContent gridLayer = new GridLayerContent(layerNode, this, settings);
                    if (gridLayer != null)
                        this.Layers.Add(gridLayer);
                }
                else if (layerSettings is TileLayerSettingsContent)
                {
                    TileLayerSettingsContent settings = layerSettings as TileLayerSettingsContent;
                    TileLayerContent tileLayer = new TileLayerContent(layerNode, this, settings);
                    if (tileLayer != null)
                        this.Layers.Add(tileLayer);
                }
                else if (layerSettings is ObjectLayerSettingsContent)
                {
                    ObjectLayerContent objectLayer = new ObjectLayerContent(layerNode, this);
                    if(objectLayer != null)
                       this.Layers.Add(objectLayer);
                }
            }
        }
    }
}
