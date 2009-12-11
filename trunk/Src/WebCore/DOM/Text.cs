using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Text : Node
    {
        public override NodeType NodeType
        {
            get
            {
                return NodeType.Text;
            }
        }

        public override string NodeName
        {
            get
            {
                return "#text";
            }
        }
    }
}
