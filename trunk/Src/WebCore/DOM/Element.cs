using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Element : Node
    {
        public Element(Document document)
            : base(document)
        {

        }

        public override NamedNodeMap Attributes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.Element;
            }
        }


        string tagName;

        public string TagName
        {
            get
            {
                return tagName;
            }
        }
    }
}
