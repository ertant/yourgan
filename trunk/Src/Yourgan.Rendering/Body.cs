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
    public class Body : Block, ILayoutProvider
    {
        public Body(ModelNode model)
            : base(model)
        {
            this.layout = new FlowLayout(this);
        }

        ILayout layout;

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }
        }

        public override float PixelsHeight
        {
            get
            {
                return this.ParentElement.PixelsHeight;
            }
        }

        public override float PixelsWidth
        {
            get
            {
                return this.ParentElement.PixelsWidth;
            }
        }

        protected internal override void OnChildrenAdded(IEnumerable<GraphicNode> affectedChilds)
        {
            base.OnChildrenAdded(affectedChilds);
            this.Layout.Invalidate();
        }

        protected internal override void OnChildrenRemoved(IEnumerable<GraphicNode> affectedChilds)
        {
            base.OnChildrenRemoved(affectedChilds);
            this.Layout.Invalidate();
        }

        protected override void CorePaint(DrawingContext drawingContext)
        {
            this.Layout.PerformLayoutIfRequired();

            base.CorePaint(drawingContext);
        }
    }
}
