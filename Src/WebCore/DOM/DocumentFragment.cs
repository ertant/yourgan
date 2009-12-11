using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class DocumentFragment : Node
    {
        public override NodeType NodeType
        {
            get
            {
                return NodeType.DocumentFragment;
            }
        }

        public override string NodeName
        {
            get
            {
                return "#document-fragment";
            }
        }
    }
}
