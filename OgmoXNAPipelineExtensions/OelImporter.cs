using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using OgmoXNAPipelineExtensions.ContentItems;

namespace OgmoXNAPipelineExtensions
{
    [ContentImporter(".oel", DisplayName = "Ogmo Editor Level Importer", DefaultProcessor = "OelProcessor")]
    public class OelImporter : ContentImporter<OelContent>
    {
        public override OelContent Import(string filename, ContentImporterContext context)
        {
            OelContent content = new OelContent();
            content.Document = new System.Xml.XmlDocument();
            content.Document.Load(filename);
            content.Directory = filename.Remove(filename.LastIndexOf('\\'));
            content.Filename = filename;
            return content;
        }
    }
}
