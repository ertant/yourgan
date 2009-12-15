using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLQuoteElement : HTMLElement
    {
        public HTMLQuoteElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract string Cite
        {
            get;
            set;
        }
    }
}
