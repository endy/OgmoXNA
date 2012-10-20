using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Graphics;
using OgmoXNAPipelineExtensions.ContentItems;

namespace OgmoXNAPipelineExtensions
{
    [ContentProcessor(DisplayName = "Ogmo Editor Level Processor")]
    public class OelProcessor : ContentProcessor<OelContent, LevelContent>
    {
        [DisplayName("Project File")]
        [Description("A relative path to the project file associated with this level.")]
        public string OgmoProjectFile { get; set; }

        public override LevelContent Process(OelContent input, ContentProcessorContext context)
        {
            if (string.IsNullOrEmpty(this.OgmoProjectFile))
                throw new Exception("No project file specified.");
            if (!this.OgmoProjectFile.EndsWith(".oep"))
                this.OgmoProjectFile += ".oep";
            string projectPath = Path.GetFullPath(Path.Combine(input.Directory, this.OgmoProjectFile));
            string projectAsset = projectPath.Remove(projectPath.LastIndexOf('.')).Substring(Directory.GetCurrentDirectory().Length + 1);
            ProjectContent projectContent = context.BuildAndLoadAsset<OepContent, ProjectContent>(
                new ExternalReference<OepContent>(projectPath),
                "OepProcessor",
                new OpaqueDataDictionary(),
                "OepImporter");
            LevelContent levelContent = new LevelContent(projectContent, input.Document);
            levelContent.ProjectReference = context.BuildAsset<OepContent, ProjectContent>(
                new ExternalReference<OepContent>(projectPath),
                "OepProcessor",
                new OpaqueDataDictionary(),
                "OepImporter",
                projectAsset);
            return levelContent;
        }
    }
}