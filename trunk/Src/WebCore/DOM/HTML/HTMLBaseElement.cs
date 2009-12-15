using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLBaseElement : HTMLElement
    {
        public abstract string HRef
        {
            get;
            set;
        }

        public abstract string Target
        {
            get;
            set;
        }
    }
}
