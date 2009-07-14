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
    public abstract class GraphicElement : GraphicNode
    {
        protected GraphicElement()
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

        public virtual float ClientTop
        {
            get
            {
                return this.ParentElement.ClientTop;
            }
        }

        public virtual float ClientLeft
        {
            get
            {
                return this.ParentElement.ClientLeft;
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
                return this.ParentElement.ScrollTop;
            }
        }

        public virtual float ScrollLeft
        {
            get
            {
                return this.ParentElement.ScrollLeft;
            }
        }

        public virtual float ScrollWidth
        {
            get
            {
                return this.ParentElement.ScrollWidth;
            }
        }

        public virtual float ScrollHeight
        {
            get
            {
                return this.ParentElement.ScrollHeight;
            }
        }

        float offsetTop = -1;

        public virtual float OffsetTop
        {
            get
            {
                if (this.offsetTop < 0)
                    return this.ParentElement.OffsetTop;
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
                    return this.ParentElement.OffsetLeft;
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

        protected override void CorePaint(DrawingContext drawingContext)
        {
            ILayoutProvider layoutProvider = this as ILayoutProvider;

            if (layoutProvider != null)
            {
                drawingContext.PushTransform();

                drawingContext.Translate(this.OffsetLeft, this.OffsetTop);
            }

            base.CorePaint(drawingContext);

            if (layoutProvider != null)
            {
                drawingContext.PopTransform();
            }
        }
    }
}
