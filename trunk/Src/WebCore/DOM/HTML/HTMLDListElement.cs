using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLDListElement : HTMLElement
    {
        public HTMLDListElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract bool Compact
        {
            get;
            set;
        }
    }
}
