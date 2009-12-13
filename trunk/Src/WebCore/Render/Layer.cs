// /*
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
