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
    public abstract class GraphicContainer : GraphicObject, IChildManager
    {
        protected GraphicContainer()
        {
        }

        private GraphicObjectCollection childs;

        public GraphicObjectCollection Childs
        {
            get
            {
                if (childs == null)
                {
                    childs = new GraphicObjectCollection(this);
                }

                return childs;
            }
        }

        protected override void CorePaint(PointF offset, DrawingContext drawingContext)
        {
            offset.X += this.OffsetBounds.X;
            offset.Y += this.OffsetBounds.Y;

            foreach (GraphicObject child in this.Childs.ToArrayThreadSafe())
            {
                child.Paint(offset, drawingContext);
            }
        }

        #region IChildManager

        public void AddChildren(IEnumerable<GraphicObject> objects)
        {
            this.Childs.AddRange(objects);
        }

        public void RemoveChildren(IEnumerable<GraphicObject> objects)
        {
            this.Childs.RemoveRange(objects);
        }

        protected internal virtual void OnChildrenRemoved(IEnumerable<GraphicObject> objects)
        {

        }

        protected internal virtual void OnChildrenAdded(IEnumerable<GraphicObject> objects)
        {

        }

        #endregion
    }
}
