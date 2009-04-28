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
    public class Block : GraphicContainer, ILayoutProvider
    {
        public Block(ModelNode model)
        {
            this.model = model;
            this.layout = new FlowLayout(this);
        }

        protected override void OnBoundsChanged()
        {
            base.OnBoundsChanged();
            this.Layout.Invalidate();
        }

        private GraphicContainer parent;

        public GraphicContainer Parent
        {
            get
            {
                return parent;
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

        private ILayout layout;

        public ILayout Layout
        {
            get
            {
                return layout;
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

        public override System.Drawing.SizeF GetPreferredSize(System.Drawing.SizeF proposedSize)
        {
            SizeF size = SizeF.Empty;

            if (this.Childs.Count == 0)
            {
                return new SizeF(50, 50);
            }

            foreach (GraphicObject child in this.Childs.ToArrayThreadSafe())
            {
                size += child.GetPreferredSize(SizeF.Empty);
            }

            return size;
        }

        protected override void CorePaint(DrawingContext drawingContext)
        {
            this.Layout.PerformLayoutIfRequired();

            if (this.Childs.Count == 0)
            {
                drawingContext.Graphics.DrawRectangle(Pens.Black, this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height);
            }
            else
                base.CorePaint(drawingContext);
        }
    }
}
