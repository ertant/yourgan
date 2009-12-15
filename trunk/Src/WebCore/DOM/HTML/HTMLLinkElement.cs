using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLLinkElement : HTMLElement
    {
        public abstract bool Disabled
        {
            get;
            set;
        }

        public abstract string Charset
        {
            get;
            set;
        }

        public abstract string HRef
        {
            get;
            set;
        }

        public abstract string HRefLang
        {
            get;
            set;
        }

        public abstract string Media
        {
            get;
            set;
        }

        public abstract string Rel
        {
            get;
            set;
        }

        public abstract string Rev
        {
            get;
            set;
        }

        public abstract string Target
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
