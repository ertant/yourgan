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
    public abstract class GraphicObject
    {
        protected GraphicObject()
        {
            this.style = new Style();
        }

        private Style style;

        public Style Style
        {
            get
            {
                return style;
            }
        }

        private GraphicContainer parent;

        public GraphicContainer Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public virtual float ClientTop
        {
            get
            {
                return parent.ClientTop;
            }
        }

        public virtual float ClientLeft
        {
            get
            {
                return parent.ClientLeft;
            }
        }

        public virtual float ClientWidth
        {
            get
            {
                return this.OffsetWidth + this.Style.Padding.Horizontal;
            }
        }

        public virtual float ClientHeight
        {
            get
            {
                return this.OffsetHeight + this.Style.Padding.Vertical;
            }
        }

        public virtual float ScrollTop
        {
            get
            {
                return parent.ScrollTop;
            }
        }

        public virtual float ScrollLeft
        {
            get
            {
                return parent.ScrollLeft;
            }
        }

        public virtual float ScrollWidth
        {
            get
            {
                return parent.ScrollWidth;
            }
        }

        public virtual float ScrollHeight
        {
            get
            {
                return parent.ScrollHeight;
            }
        }

        float offsetTop = -1;

        public virtual float OffsetTop
        {
            get
            {
                if (this.offsetTop < 0)
                    return parent.OffsetTop;
                else
                    return this.offsetTop;
            }
        }

        float offsetLeft = -1;

        public virtual float OffsetLeft
        {
            get
            {
                if (this.offsetLeft < 0)
                    return parent.OffsetLeft;
                else
                    return this.offsetLeft;
            }
        }

        public float OffsetWidth
        {
            get
            {
                return this.PixelsWidth;
            }
        }

        public float OffsetHeight
        {
            get
            {
                return this.PixelsHeight;
            }
        }

        float pixelsWidth;

        public virtual float PixelsWidth
        {
            get
            {
                return pixelsWidth;
            }
        }

        float pixelsHeight;

        public virtual float PixelsHeight
        {
            get
            {
                return pixelsHeight;
            }
        }

        internal void UpdateOffset(float x, float y)
        {
            this.offsetLeft = x;
            this.offsetTop = y;
        }

        internal void UpdateSize(float width, float height)
        {
            if (width > 0)
                this.pixelsWidth = width;

            if (height > 0)
                this.pixelsHeight = height;
        }

        private Document ownerDocument;

        public Document OwnerDocument
        {
            get
            {
                return ownerDocument;
            }
            set
            {
                ownerDocument = value;
            }
        }

        protected virtual void CorePaint(DrawingContext drawingContext)
        {
        }

        public void Paint(DrawingContext drawingContext)
        {
            CorePaint(drawingContext);
        }
    }
}
