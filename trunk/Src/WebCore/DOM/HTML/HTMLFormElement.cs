using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFormElement : HTMLElement
    {
        public abstract HTMLCollection Elements
        {
            get;
        }

        public abstract int Length
        {
            get;
        }

        public abstract string Name
        {
            get;
            set;
        }

        public abstract string AcceptCharset
        {
            get;
            set;
        }

        public abstract string Action
        {
            get;
            set;
        }

        public abstract string EncType
        {
            get;
            set;
        }

        public abstract string Method
        {
            get;
            set;
        }

        public abstract string Target
        {
            get;
            set;
        }

        public abstract void Submit();

        public abstract void Reset();
    }
}
