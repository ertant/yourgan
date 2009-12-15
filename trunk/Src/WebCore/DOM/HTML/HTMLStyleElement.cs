using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLStyleElement: HTMLElement
    {
        public abstract bool Disabled
        {
            get;
            set;
        }

        public abstract string Media
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
