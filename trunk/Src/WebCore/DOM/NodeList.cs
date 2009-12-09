using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class NodeList
    {
        IList<Node> nodes;

        public NodeList(IList<Node> nodes)
        {
            this.nodes = nodes;
        }

        public Node this[int index]
        {
            get
            {
                return this.nodes[index];
            }
        }

        public int Length
        {
            get
            {
                return this.nodes.Count;
            }
        }
    }
}
