using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFontElement : HTMLElement
    {
        public HTMLFontElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract string Color
        {
            get;
            set;
        }

        public abstract string Face
        {
            get;
            set;
        }

        public abstract string Size
        {
            get;
            set;
        }
    }
}
