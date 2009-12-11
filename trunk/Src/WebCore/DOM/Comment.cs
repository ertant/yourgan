using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Comment : Node
    {
        public override NodeType NodeType
        {
            get
            {
                return NodeType.Comment;
            }
        }

        public override string NodeName
        {
            get
            {
                return "#comment";
            }
        }
    }
}
