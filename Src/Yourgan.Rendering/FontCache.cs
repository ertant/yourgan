﻿// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
using System.Collections.Generic;
using System.Drawing;

namespace Yourgan.Rendering
{
    class FontCache
    {
        private static Dictionary<int, FontCache> ThreadContexts;
        private Image image;
        private Graphics graphics;
        private StringFormat format;

        static FontCache()
        {
            ThreadContexts = new Dictionary<int, FontCache>();
        }

        private FontCache()
        {
            format = new StringFormat();
            image = new Bitmap(1, 1);
            graphics = Graphics.FromImage(image);
        }

        private SizeF InternalMeasureString(string text, Font font, SizeF maxSize)
        {
            return graphics.MeasureString(text, font.CachedFont, maxSize, format);
        }

        public static SizeF MeasureString(string text, Font font, SizeF maxSize)
        {
            FontCache cache;

            lock (ThreadContexts)
            {
                if (!ThreadContexts.TryGetValue(System.Threading.Thread.CurrentThread.ManagedThreadId, out cache))
                {
                    cache = new FontCache();

                    ThreadContexts[System.Threading.Thread.CurrentThread.ManagedThreadId] = cache;
                }
            }

            return cache.InternalMeasureString(text, font, maxSize);
        }
    }
}
