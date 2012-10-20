using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    static class ValueContentTemplateWriter
    {
        internal static void Write(ContentWriter writer, ValueTemplateContent content)
        {
            if (content is BooleanValueTemplateContent)
            {
                BooleanValueTemplateContent bContent = content as BooleanValueTemplateContent;
                writer.Write("b");
                writer.Write(bContent.Name);
                writer.Write(bContent.Default);
            }
            else if (content is IntegerValueTemplateContent)
            {
                IntegerValueTemplateContent iContent = content as IntegerValueTemplateContent;
                writer.Write("i");
                writer.Write(iContent.Name);
                writer.Write(iContent.Default);
                writer.Write(iContent.Max);
                writer.Write(iContent.Min);
            }
            else if (content is NumberValueTemplateContent)
            {
                NumberValueTemplateContent nContent = content as NumberValueTemplateContent;
                writer.Write("n");
                writer.Write(nContent.Name);
                writer.Write(nContent.Default);
                writer.Write(nContent.Max);
                writer.Write(nContent.Min);
            }
            else if (content is StringValueTemplateContent)
            {
                StringValueTemplateContent sContent = content as StringValueTemplateContent;
                writer.Write("s");
                writer.Write(sContent.Name);
                writer.Write(sContent.Default);
                writer.Write(sContent.MaxChars);
            }
        }
    }
}
