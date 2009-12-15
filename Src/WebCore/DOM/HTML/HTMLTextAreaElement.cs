using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLTextAreaElement : HTMLBaseInputElement
    {


        public abstract int Cols
        {
            get;
            set;
        }

        public abstract int Rows
        {
            get;
            set;
        }

        public abstract bool Readonly
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
    }
}
