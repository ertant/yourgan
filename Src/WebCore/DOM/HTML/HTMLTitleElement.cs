using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLTitleElement : HTMLElement
    {
        public abstract string Text
        {
            get;
            set;
        }
    }
}
