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
using System.Text;
using System.Drawing;

namespace Yourgan.Rendering
{
    public class Word : GraphicElement
    {
        public Word(ModelNode model, string text, Font font)
        {
            this.model = model;
            this.text = text;
            this.font = font;
            this.Style.Display = DisplayMode.Inline;
        }

        private string text;

        public string Text
        {
            get
            {
                return text;
            }
        }

        private ModelNode model;

        public ModelNode Model
        {
            get
            {
                return model;
            }
        }

        private Font font;

        public Font Font
        {
            get
            {
                return font;
            }
        }

        public override float ClientWidth
        {
            get
            {
                return 0;
            }
        }

        public override float ClientHeight
        {
            get
            {
                return 0;
            }
        }

        public override float PixelsHeight
        {
            get
            {
                SizeF size = GetAutoSize();

                return size.Height;
            }
        }

        public override float PixelsWidth
        {
            get
            {
                SizeF size = GetAutoSize();

                return size.Width;
            }
        }

        private SizeF GetAutoSize()
        {
            return FontCache.MeasureString(this.text, this.font, new SizeF(this.ScrollWidth, 0));
        }

        protected override void CorePaint(DrawingContext drawingContext)
        {
            RectangleF rect = new RectangleF(this.OffsetLeft, this.OffsetTop, this.OffsetWidth, this.OffsetHeight);

            drawingContext.Graphics.DrawString(this.text, font.CachedFont, SystemBrushes.WindowText, rect);
            drawingContext.Graphics.DrawRectangle(SystemPens.MenuHighlight, rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}
