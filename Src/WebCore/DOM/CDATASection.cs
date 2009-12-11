using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class CDATASection : Node
    {
        public override NodeType NodeType
        {
            get
            {
                return NodeType.CData;
            }
        }

        public override string NodeName
        {
            get
            {
                return "#cdata-section";
            }
        }
    }
}
