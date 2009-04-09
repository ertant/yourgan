using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public enum EntityType : int
    {
        DOCType = 0,
        OpenElement = 1,
        CloseElement = 2,
        Comment = 3,
        Data = 4,
        WhiteSpace = 5
    }
}
