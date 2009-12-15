using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLButtonElement : HTMLBaseInputElement
    {
        public abstract string Value
        {
            get;
            set;
        }
    }
}
