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
    public class GraphicObject
    {
        public GraphicObject()
        {
        }

        private RectangleF bounds;

        public RectangleF Bounds
        {
            get
            {
                return bounds;
            }
            set
            {
                bounds = value;
                OnBoundsChanged();
            }
        }

        protected virtual void OnBoundsChanged()
        {
        }

        public float X
        {
            get
            {
                return this.Bounds.X;
            }
        }

        public float Y
        {
            get
            {
                return this.Bounds.Y;
            }
        }

        public float Width
        {
            get
            {
                return this.Bounds.Width;
            }
        }

        public float Height
        {
            get
            {
                return this.Bounds.Height;
            }
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

        public void Move(PointF position)
        {
            this.Bounds.Offset(position);
        }

        public virtual SizeF GetPreferredSize(SizeF proposedSize)
        {
            return proposedSize;
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
