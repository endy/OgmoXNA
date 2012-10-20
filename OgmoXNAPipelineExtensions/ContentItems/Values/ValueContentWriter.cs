using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace OgmoXNAPipelineExtensions.ContentItems.Values
{
    static class ValueContentWriter
    {
        internal static void Write(ContentWriter writer, ValueContent content)
        {
            if (content is BooleanValueContent)
            {
                BooleanValueContent bContent = content as BooleanValueContent;
                writer.Write("b");
                writer.Write(bContent.Name);
                writer.Write(bContent.Value);
            }
            else if (content is IntegerValueContent)
            {
                IntegerValueContent iContent = content as IntegerValueContent;
                writer.Write("i");
                writer.Write(iContent.Name);
                writer.Write(iContent.Value);
            }
            else if (content is NumberValueContent)
            {
                NumberValueContent nContent = content as NumberValueContent;
                writer.Write("n");
                writer.Write(nContent.Name);
                writer.Write(nContent.Value);
            }
            else if (content is StringValueContent)
            {
                StringValueContent sContent = content as StringValueContent;
                writer.Write("s");
                writer.Write(sContent.Name);
                writer.Write(sContent.Value);
            }
        }
    }
}
