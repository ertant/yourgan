using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Comment : CharacterData
    {
        public Comment(Document document)
            : base(document)
        {
            
        }

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

        public override string NodeValue
        {
            get
            {
                return this.Data;
            }
            set
            {
                this.Data = value;
            }
        }
    }
}
