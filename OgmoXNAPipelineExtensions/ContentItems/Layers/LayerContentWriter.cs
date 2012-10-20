using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using OgmoXNAPipelineExtensions.ContentItems.Values;

namespace OgmoXNAPipelineExtensions.ContentItems.Layers
{
    static class LayerContentWriter
    {
        internal static void Write(ContentWriter writer, LayerContent content)
        {
            if (content is GridLayerContent)
            {
                GridLayerContent gridLayer = content as GridLayerContent;
                writer.Write("g");
                writer.Write(gridLayer.Name);
                if (gridLayer.RectangleData != null && gridLayer.RectangleData.Count > 0)
                {
                    writer.Write(gridLayer.RectangleData.Count);
                    foreach (Rectangle rect in gridLayer.RectangleData)
                    {
                        writer.Write(rect.X);
                        writer.Write(rect.Y);
                        writer.Write(rect.Width);
                        writer.Write(rect.Height);
                    }
                }
                else if (!string.IsNullOrEmpty(gridLayer.RawData))
                    writer.Write(gridLayer.RawData);
            }
            else if (content is TileLayerContent)
            {
                TileLayerContent tileLayer = content as TileLayerContent;
                writer.Write("t");
                writer.Write(tileLayer.Name);
                writer.Write(tileLayer.TileHeight);
                writer.Write(tileLayer.TileWidth);
                writer.Write(tileLayer.Tilesets.Count);
                if (tileLayer.Tilesets.Count > 0)
                {
                    foreach (string tileset in tileLayer.Tilesets)
                        writer.Write(tileset);
                }
                writer.Write(tileLayer.Tiles.Count);
                if (tileLayer.Tiles.Count > 0)
                {
                    foreach (TileContent tile in tileLayer.Tiles)
                    {
                        writer.Write(tile.Height);
                        writer.Write(tile.Position);
                        writer.Write(tile.SourceIndex);
                        writer.Write(tile.TextureOffset);
                        writer.Write(tile.TilesetName);
                        writer.Write(tile.Width);
                    }
                }
            }
            else if (content is ObjectLayerContent)
            {
                ObjectLayerContent objLayer = content as ObjectLayerContent;
                writer.Write("o");
                writer.Write(objLayer.Name);
                writer.Write(objLayer.Objects.Count);
                if (objLayer.Objects.Count > 0)
                {
                    foreach (ObjectContent obj in objLayer.Objects)
                    {
                        writer.Write(obj.Name);
                        writer.Write(obj.Origin);
                        writer.Write(obj.Position);
                        writer.Write(obj.Rotation);
                        writer.Write(obj.Width);
                        writer.Write(obj.Height);
                        writer.Write(obj.Source.X);
                        writer.Write(obj.Source.Y);
                        writer.Write(obj.Source.Width);
                        writer.Write(obj.Source.Height);
                        writer.Write(obj.IsTiled);
                        writer.WriteExternalReference(obj.TextureReference);
                        writer.Write(obj.Values.Count);
                        if (obj.Values.Count > 0)
                        {
                            foreach (ValueContent valueContent in obj.Values)
                                ValueContentWriter.Write(writer, valueContent);
                        }
                        writer.Write(obj.Nodes.Count);
                        if (obj.Nodes.Count > 0)
                        {
                            foreach (OgmoXNAPipelineExtensions.ContentItems.NodeContent nodeContent in obj.Nodes)
                                writer.Write(nodeContent.Position);
                        }
                    }
                }
            }
        }
    }
}
