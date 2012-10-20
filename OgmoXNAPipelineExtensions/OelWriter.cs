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
using OgmoXNAPipelineExtensions.ContentItems.Values;
using OgmoXNAPipelineExtensions.ContentItems.Layers;
using OgmoXNAPipelineExtensions.ContentItems.Layers.Settings;
using System.Reflection;

namespace OgmoXNAPipelineExtensions
{
    [ContentTypeWriter]
    public class OelWriter : ContentTypeWriter<LevelContent>
    {
        protected override void Write(ContentWriter output, LevelContent value)
        {
            // Project
            output.WriteExternalReference(value.ProjectReference);
            // Values/attributes
            output.Write(value.Values.Count);
            if (value.Values.Count > 0)
            {
                foreach (ValueContent valueContent in value.Values)
                    ValueContentWriter.Write(output, valueContent);
            }
            // Height
            output.Write(value.Height);
            // Width
            output.Write(value.Width);
            // Layers
            output.Write(value.Layers.Count);
            if (value.Layers.Count > 0)
            {
                foreach (LayerContent layerContent in value.Layers)
                    LayerContentWriter.Write(output, layerContent);
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "OgmoXNA.OgmoLevelReader, OgmoXNA";
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "OgmoXna.OgmoLevel, OgmoXNA";
        }
    }
}
