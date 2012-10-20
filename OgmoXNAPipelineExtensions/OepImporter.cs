using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using OgmoXNAPipelineExtensions.ContentItems;

namespace OgmoXNAPipelineExtensions
{
    [ContentImporter(".oep", DisplayName = "Ogmo Editor Project Importer", DefaultProcessor = "OepProcessor")]
    public class OepImporter : ContentImporter<OepContent>
    {
        public override OepContent Import(string filename, ContentImporterContext context)
        {
            OepContent content = new OepContent();
            content.Document = new System.Xml.XmlDocument();
            content.Document.Load(filename);
            content.Directory = filename.Remove(filename.LastIndexOf('\\'));
            content.Filename = filename;
            return content;
        }
    }
}
