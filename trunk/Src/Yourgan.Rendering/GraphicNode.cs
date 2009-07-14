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

namespace Yourgan.Rendering
{
    public class GraphicNode
    {
        private GraphicNodeCollection childs;

        public GraphicNodeCollection Childs
        {
            get
            {
                if (childs == null)
                {
                    childs = new GraphicNodeCollection(this);
                }

                return childs;
            }
        }

        private GraphicNode parent;

        public GraphicNode Parent
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

        public GraphicElement ParentElement
        {
            get
            {
                GraphicNode tmpParent = this.Parent;
                GraphicElement element;

                do
                {
                    element = parent as GraphicElement;

                    tmpParent = tmpParent.Parent;

                } while ((element == null) && (tmpParent != null));

                return element;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public ILayoutProvider GetParentLayout()
        {
            ILayoutProvider layout;
            GraphicNode tmpParent = this.Parent;

            do
            {
                layout = tmpParent as ILayoutProvider;

                if (tmpParent != null)
                {
                    tmpParent = tmpParent.Parent;
                }

            } while ((layout == null) && (tmpParent != null));

            return layout;
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

        protected virtual void CorePaint(DrawingContext drawingContext)
        {
            foreach (GraphicNode child in this.Childs.ToArrayThreadSafe())
            {
                child.Paint(drawingContext);
            }
        }

        public void Paint(DrawingContext drawingContext)
        {
            CorePaint(drawingContext);
        }

        #region IChildManager

        public void AddChildren(IEnumerable<GraphicNode> objects)
        {
            this.Childs.AddRange(objects);
        }

        public void RemoveChildren(IEnumerable<GraphicNode> objects)
        {
            this.Childs.RemoveRange(objects);
        }

        protected internal virtual void OnChildrenRemoved(IEnumerable<GraphicNode> affectedChilds)
        {
            ILayoutProvider layoutNode = GetParentLayout();

            if (layoutNode != null)
                layoutNode.Layout.Invalidate();
        }

        protected internal virtual void OnChildrenAdded(IEnumerable<GraphicNode> affectedChilds)
        {
            ILayoutProvider layoutNode = GetParentLayout();

            if (layoutNode != null)
                layoutNode.Layout.Invalidate();
        }

        #endregion
    }
}
