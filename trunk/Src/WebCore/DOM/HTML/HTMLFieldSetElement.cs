using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFieldSetElement : HTMLElement
    {
        public abstract HTMLFormElement Form
        {
            get;
        }
    }
}
