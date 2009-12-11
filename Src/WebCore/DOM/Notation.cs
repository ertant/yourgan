using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public abstract class Notation : Node
    {
        public override NodeType NodeType
        {
            get
            {
                return NodeType.Notation;
            }
        }

        public override string NodeName
        {
            get
            {
                return null;
            }
        }
    }
}
