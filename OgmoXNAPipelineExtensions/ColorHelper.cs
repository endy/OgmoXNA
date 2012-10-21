using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OgmoXNAPipelineExtensions
{
    /// <summary>
    /// A helper class for <see cref="Color"/>.
    /// </summary>
    internal static class ColorHelper
    {
        /// <summary>
        /// Extract an ARGB or RGB color value from a hex string.  The string may begin with or without the hash (#)
        /// character.
        /// </summary>
        /// <param name="hexString">The hex value to parse.</param>
        /// <returns>Returns a <see cref="Color"/> object as defined by the hex string.</returns>
        internal static Color FromHex(string hexString)
        {
            // See if we have a hash at the start of the string, and have more than just that.  Then remove it so
            // we can work with a clean value.
            if (hexString.StartsWith("#") && hexString.Length > 1)
                hexString = hexString.Substring(1, hexString.Length - 1);
            byte a = 255, r = 0, g = 0, b = 0;
            int firstIndex = 2;
            // Determine if we're working with RGB or ARGB.
            if (hexString.Length == 6)
            {
                // RGB, so assume the max alpha value.
                a = 255;
                firstIndex = 0;
            }
            else if (hexString.Length == 8)
            {
                // ARGB, so get the alpha component.
                a = byte.Parse(hexString.Substring(0, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            else
            {
                throw new InvalidOperationException("Unexpected hex string length.");
            }
            // Get the red component.
            r = byte.Parse(hexString.Substring(firstIndex, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            // Get the green component.
            g = byte.Parse(hexString.Substring(firstIndex + 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            // Get the blue component.
            b = byte.Parse(hexString.Substring(firstIndex + 4, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            return new Color(r, g, b, a);
        }

        /// <summary>
        /// Extra a hex string from an ARGB color value.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> value to parse.</param>
        /// <param name="includeHash">Determines if the hash character (#) is included in the string.</param>
        /// <returns>Returns a hex string value representing the specified <see cref="Color"/> value.</returns>
        internal static string ToHex(Color color, bool includeHash)
        {
            // Do we want the hash mark?
            string hash = (includeHash ? "#" : string.Empty);
            // Here we use the ToString method's format specified override to convert each color's ARGB byte value
            // to a two digit hex number.
            string[] argb = new string[]
            {
                color.A.ToString("X2"),
                color.R.ToString("X2"),
                color.G.ToString("X2"),
                color.B.ToString("X2"),
            };
            // Combine and return the results.
            return hash + string.Join(string.Empty, argb);
        }
    }
}
