using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLInputElement : HTMLBaseInputElement
    {
        public abstract bool DefaultChecked
        {
            get;
            set;
        }

        public abstract string Accept
        {
            get;
            set;
        }

        public abstract string Align
        {
            get;
            set;
        }

        public abstract string Alt
        {
            get;
            set;
        }

        public abstract bool Checked
        {
            get;
            set;
        }

        public abstract int MaxLength
        {
            get;
            set;
        }

        public abstract bool Readonly
        {
            get;
            set;
        }

        public abstract int Size
        {
            get;
            set;
        }

        public abstract string Src
        {
            get;
            set;
        }


        public abstract string UseMap
        {
            get;
            set;
        }

        public abstract string Value
        {
            get;
            set;
        }

        public abstract void Select();

        public abstract void Click();
    }
}
