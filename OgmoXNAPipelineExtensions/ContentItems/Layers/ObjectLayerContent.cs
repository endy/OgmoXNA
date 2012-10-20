using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;
using OgmoXNAPipelineExtensions.ContentItems.Values;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers
{
    public class ObjectLayerContent : LayerContent
    {
        public List<ObjectContent> Objects = new List<ObjectContent>();

        public ObjectLayerContent()
        {
        }

        public ObjectLayerContent(XmlNode node, LevelContent level) 
            : base(node)
        {
            // Construct xpath query for all available objects.
            string[] objectNames = (from x in level.Project.Objects select x.Name).ToArray<string>();
            string xpath = string.Join("|", objectNames);
            foreach (XmlNode objectNode in node.SelectNodes(xpath))
            {
                ObjectTemplateContent objTemplate = level.Project.Objects.First<ObjectTemplateContent>((x) => { return x.Name.Equals(objectNode.Name); });
                if (objTemplate != null)
                {
                    ObjectContent obj = new ObjectContent(objectNode, objTemplate);
                    foreach (ValueTemplateContent valueContent in objTemplate.Values)
                    {
                        XmlAttribute attribute = null;
                        if ((attribute = objectNode.Attributes[valueContent.Name]) != null)
                        {
                            if (valueContent is BooleanValueTemplateContent)
                                obj.Values.Add(new BooleanValueContent(valueContent.Name, bool.Parse(attribute.Value)));
                            else if (valueContent is IntegerValueTemplateContent)
                                obj.Values.Add(new IntegerValueContent(valueContent.Name,
                                    int.Parse(attribute.Value, CultureInfo.InvariantCulture)));
                            else if (valueContent is NumberValueTemplateContent)
                                obj.Values.Add(new NumberValueContent(valueContent.Name,
                                    float.Parse(attribute.Value, CultureInfo.InvariantCulture)));
                            else if (valueContent is StringValueTemplateContent)
                                obj.Values.Add(new StringValueContent(valueContent.Name, attribute.Value));
                        }
                    }
                    foreach (XmlNode nodeNode in objectNode.SelectNodes("node"))
                        obj.Nodes.Add(new NodeContent(nodeNode));
                    this.Objects.Add(obj);
                }
            }
        }
    }
}
