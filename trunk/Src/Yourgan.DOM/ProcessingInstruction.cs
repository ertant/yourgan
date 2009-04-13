using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public interface ProcessingInstruction : Node
    {
        string target
        {
            get;
        }

        string data
        {
            get;
            set;
        }
    }
}
