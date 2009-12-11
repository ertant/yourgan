using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class ProcessingInstruction : Node
    {
        string target;

        public string Target
        {
            get
            {
                return target;
            }
        }

        string data;

        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.ProcessingInstruction;
            }
        }

        public override string NodeName
        {
            get
            {
                return this.Data;
            }
        }
    }
}
