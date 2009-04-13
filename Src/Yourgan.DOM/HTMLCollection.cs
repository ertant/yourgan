using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public interface HTMLCollection
    {
        long length
        {
            get;
        }

        Element this[long index]
        {
            get;
        }

        Element namedItem(long index);
    }
}
