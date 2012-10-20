using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers.Settings
{
    static class LayerSettingsContentWriter
    {
        internal static void Write(ContentWriter writer, LayerSettingsContent content)
        {
            if (content is GridLayerSettingsContent)
            {
                GridLayerSettingsContent gContent = content as GridLayerSettingsContent;
                writer.Write("g");
                writer.Write(gContent.GridColor);
                writer.Write(gContent.GridDrawSize);
                writer.Write(gContent.GridSize);
                writer.Write(gContent.Name);
                writer.Write(gContent.ExportAsObjects);
                writer.Write(gContent.NewLine);
            }
            else if (content is ObjectLayerSettingsContent)
            {
                ObjectLayerSettingsContent oContent = content as ObjectLayerSettingsContent;
                writer.Write("o");
                writer.Write(oContent.GridColor);
                writer.Write(oContent.GridDrawSize);
                writer.Write(oContent.GridSize);
                writer.Write(oContent.Name);
            }
            else if (content is TileLayerSettingsContent)
            {
                TileLayerSettingsContent tContent = content as TileLayerSettingsContent;
                writer.Write("t");
                writer.Write(tContent.GridColor);
                writer.Write(tContent.GridDrawSize);
                writer.Write(tContent.GridSize);
                writer.Write(tContent.Name);
                writer.Write(tContent.ExportTileIDs);
                writer.Write(tContent.ExportTileSize);
                writer.Write(tContent.MultipleTilesets);
            }
        }
    }
}
