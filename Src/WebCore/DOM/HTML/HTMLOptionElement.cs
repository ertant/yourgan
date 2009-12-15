using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLOptionElement : HTMLElement
    {
        public abstract HTMLFormElement Form
        {
            get;
        }

        public abstract bool DefaultSelected
        {
            get;
            set;
        }

        public abstract string Text
        {
            get;
        }

        public abstract int Index
        {
            get;
        }

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

        public abstract bool Selected
        {
            get;
            set;
        }

        public abstract string Value
        {
            get;
            set;
        }
    }
}
