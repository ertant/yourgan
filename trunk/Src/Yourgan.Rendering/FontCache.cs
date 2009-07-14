/*
Yourgan
Copyright (C) 2009  Ertan Tike

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
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
        private static StringFormat format;

        static FontCache()
        {
            format = new StringFormat();
        }

        public static SizeF MeasureString(string text, Font font, SizeF maxSize)
        {
            if (image == null)
            {
                image = new Bitmap(1, 1);
                graphics = Graphics.FromImage(image);
            }

            return graphics.MeasureString(text, font.CachedFont, maxSize, format);
        }
    }
}
