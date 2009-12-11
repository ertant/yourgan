using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class NodeList : LinkedList<Node>
    {
        public NodeList(Node owner)
        {
            this.owner = owner;
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
                LinkedListNode<Node> node = this.First;

                for (int i = 0; i < this.Count; i++)
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
                return this.Count;
            }
        }
    }
}
