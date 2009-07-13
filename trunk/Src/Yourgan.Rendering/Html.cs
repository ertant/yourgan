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
    public class Html : GraphicElement
    {
        public Html(ModelNode node)
        {
        }

        private Body body;

        public Body Body
        {
            get
            {
                return body;
            }
        }

        public override float ScrollHeight
        {
            get
            {
                return this.OwnerDocument.DefaultView.InnerHeight;
            }
        }

        public override float ScrollWidth
        {
            get
            {
                return this.OwnerDocument.DefaultView.InnerWidth;
            }
        }

        public override float OffsetLeft
        {
            get
            {
                return 0;
            }
        }

        public override float OffsetTop
        {
            get
            {
                return 0;
            }
        }

        protected internal override void OnChildrenAdded(IEnumerable<GraphicNode> objects)
        {
            base.OnChildrenAdded(objects);

            foreach (GraphicElement graphicObject in objects)
            {
                if (graphicObject is Body)
                {
                    this.body = graphicObject as Body;
                }
            }
        }

        protected override void CorePaint(DrawingContext drawingContext)
        {
            if (this.body != null)
            {
                this.body.Paint(drawingContext);
            }
        }
    }
}
