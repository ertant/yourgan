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

namespace Yourgan.Rendering
{
    public class GraphicNodeCollection : OwnedCollection<GraphicNode>
    {
        public GraphicNodeCollection(GraphicNode container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.owner = container;
        }

        private GraphicNode owner;

        public GraphicNode Owner
        {
            get
            {
                return owner;
            }
        }

        protected override void ClearItems()
        {
            GraphicNode[] items = this.ToArray();

            base.ClearItems();

            foreach (GraphicNode item in items)
            {
                item.Parent = null;
            }

            owner.OnChildrenRemoved(items);
        }

        protected override void InsertItems(int index, IEnumerable<GraphicNode> collection)
        {
            base.InsertItems(index, collection);

            foreach (GraphicNode item in collection)
            {
                item.Parent = this.owner;
            }

            owner.OnChildrenAdded(collection);
        }

        protected override void RemoveItems(int index, int count)
        {
            GraphicElement[] childs = new GraphicElement[count];

            ((List<GraphicElement>)base.Items).CopyTo(index, childs, 0, count);

            base.RemoveItems(index, count);

            foreach (GraphicElement item in childs)
            {
                item.Parent = null;
            }

            owner.OnChildrenRemoved(childs);
        }

        public void RemoveRange(IEnumerable<GraphicNode> childs)
        {
            List<GraphicNode> children = new List<GraphicNode>();
            List<GraphicNode> collection = new List<GraphicNode>(base.Items);

            foreach (GraphicNode obj2 in childs)
            {
                int index = collection.IndexOf(obj2);

                if (index != -1)
                {
                    collection.RemoveAt(index);
                    children.Add(obj2);
                }
            }

            if (children.Count != 0)
            {
                ((List<GraphicNode>)base.Items).Clear();
                ((List<GraphicNode>)base.Items).AddRange(collection);

                foreach (GraphicNode item in collection)
                {
                    item.Parent = null;
                }

                if (this.owner != null)
                {
                    this.owner.OnChildrenRemoved(children);
                }
            }
        }

        protected override void SetItem(int index, GraphicNode item)
        {
            throw new NotImplementedException();
        }
    }
}
