using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLLIElement : HTMLElement
    {
        public HTMLLIElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract string Type
        {
            get;
        }

        public abstract int Value
        {
            get;
            set;
        }
    }
}
