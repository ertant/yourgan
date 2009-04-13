using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public enum DocumentPosition : ushort
    {
        DISCONNECTED = 0x01,
        PRECEDING = 0x02,
        FOLLOWING = 0x04,
        CONTAINS = 0x08,
        CONTAINED_BY = 0x10,
        IMPLEMENTATION_SPECIFIC = 0x20
    }
}
