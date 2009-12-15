using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLHRElement : HTMLElement
    {
        public HTMLHRElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract string Align
        {
            get;
            set;
        }

        public abstract bool NoShade
        {
            get;
            set;
        }

        public abstract string Size
        {
            get;
            set;
        }

        public abstract string Width
        {
            get;
            set;
        }
    }
}
