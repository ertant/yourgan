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
        }

        private LayoutMode layoutMode = LayoutMode.Block;

        public LayoutMode LayoutMode
        {
            get
            {
                return layoutMode;
            }
            set
            {
                layoutMode = value;
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

        private RectangleF clientBounds;

        public RectangleF ClientBounds
        {
            get
            {
                if (clientBounds.IsEmpty)
                    return parent.ClientBounds;
                else
                    return clientBounds;
            }
            set
            {
                clientBounds = value;
                OnClientBoundsChanged();
            }
        }

        protected virtual void OnClientBoundsChanged()
        {
        }

        private RectangleF scrollBounds;

        public RectangleF ScrollBounds
        {
            get
            {
                if (scrollBounds.IsEmpty)
                    return this.ClientBounds;
                else
                    return scrollBounds;
            }
            set
            {
                scrollBounds = value;
                OnScrollBoundsChanged();
            }
        }

        protected virtual void OnScrollBoundsChanged()
        {
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
