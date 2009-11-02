using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Yourgan.Core.Drawing;

namespace Yourgan.Core.Render
{
    public class Layer
    {
        public Layer(BoxModel owner)
        {
            this.owner = owner;
        }

        private Layer parent;

        public Layer Parent
        {
            get
            {
                return parent;
            }
        }

        public void InsertToParent()
        {
            this.parent = this.Owner.Parent.EnclosingLayer;

            if (this.parent != null)
            {
                foreach (Layer child in parent.Childs)
                {
                    if (child != this)
                    {
                        this.Childs.Add(child);
                    }
                }

                this.parent.Childs.Clear();
                this.parent.Childs.Add(this);
            }
        }

        public void Destroy()
        {
            if (this.parent != null)
            {
                foreach (Layer child in this.Childs)
                {
                    this.parent.Childs.Add(child);
                }

                this.Childs.Clear();

                this.parent.Childs.Remove(this);

                this.parent = null;
            }
        }

        private LayerList childs;

        public LayerList Childs
        {
            get
            {
                if (childs == null)
                    childs = new LayerList();

                return childs;
            }
        }

        private BoxModel owner;

        public BoxModel Owner
        {
            get
            {
                return owner;
            }
        }

        public void Invalidate(Rectangle rectangle)
        {

        }

        public void Paint(IGraphicsContext context)
        {
            this.Owner.Paint(context);
        }

    }
}
