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
    public class Html : Block
    {
        public Html(ModelNode node)
            : base(node)
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

        protected override void OnClientBoundsChanged()
        {
            base.OnClientBoundsChanged();

            UpdateBodyBounds();
        }

        private void UpdateBodyBounds()
        {
            if (this.body != null)
            {
                this.body.ClientBounds = this.ClientBounds;
            }
        }

        protected internal override void OnChildrenAdded(IEnumerable<GraphicObject> objects)
        {
            base.OnChildrenAdded(objects);

            foreach (GraphicObject graphicObject in objects)
            {
                if (graphicObject is Body)
                {
                    this.body = graphicObject as Body;

                    UpdateBodyBounds();
                }
            }
        }

        protected override void CorePaint(PointF offset, DrawingContext drawingContext)
        {
            if (this.body != null)
            {
                this.body.Paint(offset, drawingContext);
            }
        }
    }
}
