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
using System.Diagnostics;
using System.Drawing;

namespace Yourgan.Rendering
{
    [DebuggerDisplay("{Model.Element.Name}")]
    public class Block : GraphicContainer
    {
        public Block(ModelNode model)
        {
            this.model = model;
            this.layout = new FlowLayout(this);
        }

        protected override void OnClientBoundsChanged()
        {
            base.OnClientBoundsChanged();
            this.Layout.Invalidate();
        }

        private ModelNode model;

        public ModelNode Model
        {
            get
            {
                return model;
            }
        }

        private ILayout layout;

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }
            set
            {
                this.layout = value;
                this.layout.Invalidate();
            }
        }

        protected internal override void OnChildrenAdded(IEnumerable<GraphicObject> objects)
        {
            base.OnChildrenAdded(objects);
            this.Layout.Invalidate();
        }

        protected internal override void OnChildrenRemoved(IEnumerable<GraphicObject> objects)
        {
            base.OnChildrenRemoved(objects);
            this.Layout.Invalidate();
        }

        public SizeF GetAutoSize(SizeF maxSize)
        {
            return this.Layout.GetAutoSize(maxSize);
        }

        public override System.Drawing.SizeF GetPreferredSize(System.Drawing.SizeF proposedSize)
        {
            return this.GetAutoSize(proposedSize);
        }

        protected override void CorePaint(PointF offset, DrawingContext drawingContext)
        {
            this.Layout.PerformLayoutIfRequired();

            base.CorePaint(offset, drawingContext);

            RectangleF client = this.OffsetBounds;

            client.Offset(offset);

            Pen pen = SystemPens.ButtonHighlight;

            drawingContext.Graphics.DrawRectangle(pen, client.X, client.Y, client.Width, client.Height);
        }
    }
}
