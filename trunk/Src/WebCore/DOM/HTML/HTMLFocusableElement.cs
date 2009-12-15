using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFocusableElement : HTMLElement
    {
        public abstract int TabIndex
        {
            get;
            set;
        }

        public abstract string AccessKey
        {
            get;
            set;
        }

        public abstract void Blur();

        public abstract void Focus();
    }
}
