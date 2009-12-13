using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Text : CharacterData
    {
        public Text(Document document)
            : base(document)
        {
        }

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

        public Text SplitText(int offset)
        {
            throw new NotImplementedException();
        }

        public bool IsElementContentWhitespace
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string WholeText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Text ReplaceWholeText(string content)
        {
            throw new NotImplementedException();
        }
    }
}
