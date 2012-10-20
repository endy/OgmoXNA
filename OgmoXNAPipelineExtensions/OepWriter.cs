using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Microsoft.Xna.Framework.Graphics;
using OgmoXNAPipelineExtensions.ContentItems;
using OgmoXNAPipelineExtensions.ContentItems.Layers.Settings;
using OgmoXNAPipelineExtensions.ContentItems.Values;

namespace OgmoXNAPipelineExtensions
{
    [ContentTypeWriter]
    public class OepWriter : ContentTypeWriter<ProjectContent>
    {
        protected override void Write(ContentWriter output, ProjectContent value)
        {
            // Name
            output.Write(value.Name);
            // Settings
            output.Write(value.Settings.Height);
            output.Write(value.Settings.MaxHeight);
            output.Write(value.Settings.MaxWidth);
            output.Write(value.Settings.MinHeight);
            output.Write(value.Settings.MinWidth);
            output.Write(value.Settings.Width);
            output.Write(value.Settings.WorkingDirectory);
            // Values
            output.Write(value.Values.Count);
            if (value.Values.Count > 0)
            {
                foreach (ValueTemplateContent valueContent in value.Values)
                    ValueContentTemplateWriter.Write(output, valueContent);
            }
            // Tilesets
            output.Write(value.Tilesets.Count);
            if (value.Tilesets.Count > 0)
            {
                foreach (TilesetContent tilesetContent in value.Tilesets)
                {
                    output.Write(tilesetContent.Name);
                    output.WriteExternalReference(tilesetContent.TextureReference);
                    output.Write(tilesetContent.TextureFile);
                    output.Write(tilesetContent.TileHeight);
                    output.Write(tilesetContent.TileWidth);
                }
            }
            // Objects
            output.Write(value.Objects.Count);
            if (value.Objects.Count > 0)
            {
                foreach (ObjectTemplateContent objContent in value.Objects)
                {
                    output.Write(objContent.Height);
                    output.Write(objContent.IsResizableX);
                    output.Write(objContent.IsResizableY);
                    output.Write(objContent.IsTiled);
                    output.Write(objContent.Name);
                    output.Write(objContent.Origin);
                    output.Write(objContent.Source.X);
                    output.Write(objContent.Source.Y);
                    output.Write(objContent.Source.Width);
                    output.Write(objContent.Source.Height);
                    output.WriteExternalReference(objContent.TextureReference);
                    output.Write(objContent.TextureFile);
                    output.Write(objContent.Width);
                    // Values
                    output.Write(objContent.Values.Count);
                    if (objContent.Values.Count > 0)
                    {
                        foreach (ValueTemplateContent valueContent in objContent.Values)
                            ValueContentTemplateWriter.Write(output, valueContent);
                    }
                }
            }
            // Layers
            output.Write(value.LayerSettings.Count);
            if (value.LayerSettings.Count > 0)
            {
                foreach (LayerSettingsContent layerSettings in value.LayerSettings)
                    LayerSettingsContentWriter.Write(output, layerSettings);
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "OgmoXNA.OgmoProjectReader, OgmoXNA";
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "OgmaXNA.OgmoProject, OgmoXNA";
        }
    }
}
