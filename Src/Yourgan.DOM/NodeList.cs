using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    // http://www.w3.org/TR/2004/REC-DOM-Level-3-Core-20040407/core.html#ID-536297177
    public interface NodeList
    {
        Node this[uint index]
        {
            get;
        }

        uint length
        {
            get;
        }
    }
}
