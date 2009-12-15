using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLUListElement : HTMLElement
    {
        public abstract bool Compact
        {
            get;
            set;
        }

        public abstract string Type
        {
            get;
            set;
        }
    }
}
