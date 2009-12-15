using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLBaseInputElement : HTMLFocusableElement
    {
        public abstract string DefaultValue
        {
            get;
            set;
        }

        public abstract HTMLFormElement Form
        {
            get;
        }

        public abstract bool Disabled
        {
            get;
            set;
        }

        public abstract string Name
        {
            get;
            set;
        }

        public abstract string Type
        {
            get;
        }
    }
}
