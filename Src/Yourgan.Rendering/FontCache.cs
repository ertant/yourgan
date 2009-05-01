using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yourgan.Rendering
{
    static class FontCache
    {
        private static Image image;
        private static Graphics graphics;

        public static SizeF MeasureString(string text, Font font, SizeF maxSize, StringFormat format)
        {
            if (image == null)
            {
                image = new Bitmap(1, 1);
                graphics = Graphics.FromImage(image);
            }

            return graphics.MeasureString(text, SystemFonts.DefaultFont, maxSize, format);
        }
    }
}
