using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLHtmlElement : HTMLElement
    {
        [DeprecatedProperty]
        public string Version
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
    }
}
