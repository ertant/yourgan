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

        public virtual RectangleF ClientBounds
        {
            get
            {
                RectangleF client = parent.ClientBounds;

                client.Offset(this.Style.Margin.Left, this.Style.Margin.Top);
                client.Size = new SizeF(client.Width - this.Style.Margin.Right, client.Height - this.Style.Margin.Bottom);

                return client;
            }
        }

        public RectangleF ScrollBounds
        {
            get
            {
                return this.ClientBounds;
            }
        }

        private RectangleF offsetBounds;

        public RectangleF OffsetBounds
        {
            get
            {
                return offsetBounds;
            }
            set
            {
                offsetBounds = value;
                OnOffsetBoundsChanged();
            }
        }

        protected virtual void OnOffsetBoundsChanged()
        {
        }

        public virtual bool HasPreferredWidth
        {
            get
            {
                return false;
            }
        }

        public virtual bool HasPreferredHeight
        {
            get
            {
                return false;
            }
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

        public virtual SizeF GetPreferredSize(SizeF proposedSize)
        {
            return proposedSize;
        }

        protected virtual void CorePaint(PointF offset, DrawingContext drawingContext)
        {

        }

        public void Paint(PointF offset, DrawingContext drawingContext)
        {
            CorePaint(offset, drawingContext);
        }
    }
}
