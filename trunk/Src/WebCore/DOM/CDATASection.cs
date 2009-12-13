using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class CDATASection : Text
    {
        public CDATASection(Document document)
            : base(document)
        {
            
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.CData;
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
                base.Data = value;
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
