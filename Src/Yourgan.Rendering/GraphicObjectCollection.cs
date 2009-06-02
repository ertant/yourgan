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
    public class GraphicObjectCollection : OwnedCollection<GraphicObject>
    {
        public GraphicObjectCollection(GraphicContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.owner = container;
        }

        private GraphicContainer owner;

        public GraphicContainer Owner
        {
            get
            {
                return owner;
            }
        }

        protected override void ClearItems()
        {
            GraphicObject[] items = this.ToArray();

            base.ClearItems();

            foreach (GraphicObject item in items)
            {
                item.Parent = null;
            }

            owner.OnChildrenRemoved(items);
        }

        protected override void InsertItems(int index, IEnumerable<GraphicObject> collection)
        {
            base.InsertItems(index, collection);

            foreach (GraphicObject item in collection)
            {
                item.Parent = this.owner;
            }

            owner.OnChildrenAdded(collection);
        }

        protected override void RemoveItems(int index, int count)
        {
            GraphicObject[] childs = new GraphicObject[count];

            ((List<GraphicObject>)base.Items).CopyTo(index, childs, 0, count);

            base.RemoveItems(index, count);

            foreach (GraphicObject item in childs)
            {
                item.Parent = null;
            }

            owner.OnChildrenRemoved(childs);
        }

        public void RemoveRange(IEnumerable<GraphicObject> childs)
        {
            List<GraphicObject> children = new List<GraphicObject>();
            List<GraphicObject> collection = new List<GraphicObject>(base.Items);

            foreach (GraphicObject obj2 in childs)
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
                ((List<GraphicObject>)base.Items).Clear();
                ((List<GraphicObject>)base.Items).AddRange(collection);

                foreach (GraphicObject item in collection)
                {
                    item.Parent = null;
                }

                if (this.owner != null)
                {
                    this.owner.OnChildrenRemoved(children);
                }
            }
        }

        protected override void SetItem(int index, GraphicObject item)
        {
            throw new NotImplementedException();
        }
    }
}
