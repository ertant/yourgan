using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLOptionsCollection
    {
        public abstract int Length
        {
            get;
        }

        public abstract Node this[int index]
        {
            get;
        }

        public abstract Node NamedItem(string name);
    }
}
