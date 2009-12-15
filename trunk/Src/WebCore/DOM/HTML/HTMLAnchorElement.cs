using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLAnchorElement : HTMLFocusableElement
    {
        public abstract string Charset
        {
            get;
            set;
        }

        public abstract string Coords
        {
            get;
            set;
        }

        public abstract string Href
        {
            get;
            set;
        }

        public abstract string HRefLang
        {
            get;
            set;
        }

        public abstract string Name
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

        public abstract string Shape
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
