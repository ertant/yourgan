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
                GraphicNode parent = this.Parent;
                GraphicElement element = null;

                do
                {
                    element = parent as GraphicElement;

                    parent = parent.Parent;

                } while ((element == null) && (parent != null));

                return element;
            }
        }

        public ILayoutProvider GetParentLayout()
        {
            ILayoutProvider layout = null;
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

        protected internal virtual void OnChildrenRemoved(IEnumerable<GraphicNode> objects)
        {
            ILayoutProvider layoutNode = GetParentLayout();

            if (layoutNode != null)
                layoutNode.Layout.Invalidate();
        }

        protected internal virtual void OnChildrenAdded(IEnumerable<GraphicNode> objects)
        {
            ILayoutProvider layoutNode = GetParentLayout();

            if (layoutNode != null)
                layoutNode.Layout.Invalidate();
        }

        #endregion
    }
}
