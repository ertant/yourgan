using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLOptGroupElement : HTMLElement
    {
        public abstract bool Disabled
        {
            get;
            set;
        }

        public abstract string Label
        {
            get;
            set;
        }
    }
}
