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
using System;
using System.Collections.Generic;

namespace Yourgan.Core.DOM
{
    public class NodeList : IEnumerable<Node>
    {
        private LinkedList<Node> innerCollection;

        public NodeList(Node owner)
        {
            this.owner = owner;
            this.innerCollection = new LinkedList<Node>();
        }

        public Node First
        {
            get
            {
                if (this.innerCollection.First != null)
                    return this.innerCollection.First.Value;

                return null;
            }
        }

        public Node Last
        {
            get
            {
                if (this.innerCollection.Last != null)
                    return this.innerCollection.Last.Value;

                return null;
            }
        }

        Node owner;

        public Node Owner
        {
            get
            {
                return owner;
            }
        }

        public Node this[int index]
        {
            get
            {
                LinkedListNode<Node> node = this.innerCollection.First;

                for (int i = 0; i < index; i++)
                {
                    node = node.Next;

                    if (node == null)
                        throw new ArgumentOutOfRangeException();
                }

                return node.Value;
            }
        }

        public int Length
        {
            get
            {
                return this.innerCollection.Count;
            }
        }

        public void Clear()
        {
            Node[] nodes = new Node[this.innerCollection.Count];

            this.innerCollection.CopyTo(nodes, 0);

            this.innerCollection.Clear();

            foreach (Node node in nodes)
            {
                node.SetParent(null, null);
            }
        }

        public Node AddBefore(Node child, Node value)
        {
            LinkedListNode<Node> realChild = this.innerCollection.AddBefore(child.ParentNodeItem, value);

            value.SetParent(this, realChild);

            this.owner.OnChildAdded(value);

            return value;
        }

        public Node AddFirst(Node child)
        {
            LinkedListNode<Node> realChild = this.innerCollection.AddFirst(child);

            child.SetParent(this, realChild);

            this.owner.OnChildAdded(child);

            return child;
        }

        public Node AddLast(Node child)
        {
            LinkedListNode<Node> realChild = this.innerCollection.AddLast(child);

            child.SetParent(this, realChild);

            this.owner.OnChildAdded(child);

            return child;
        }

        public void Remove(Node child)
        {
            this.innerCollection.Remove(child.ParentNodeItem);

            child.SetParent(null, null);

            this.owner.OnChildRemoved(child);
        }

        IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }
    }
}
