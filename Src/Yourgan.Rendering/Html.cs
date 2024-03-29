﻿// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
using System.Collections.Generic;

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

        protected internal override void OnChildrenAdded(IEnumerable<GraphicNode> affectedChilds)
        {
            base.OnChildrenAdded(affectedChilds);

            foreach (GraphicElement graphicObject in affectedChilds)
            {
                Body tmpBody = graphicObject as Body;

                if (tmpBody != null)
                {
                    this.body = tmpBody;
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
