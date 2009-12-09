using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public enum DocumentPosition : int
    {
        Disconnected = 1,
        Preceding = 2,
        Following = 3,
        Contains = 4,
        ContainedBy = 5,
        Specific = 6
    }
}
