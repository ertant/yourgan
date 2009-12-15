using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLElement : Element
    {
        public HTMLElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        // Fix : This is temporary because of too much inherited abstract classes
        protected HTMLElement()
            : base(null, null)
        {

        }

        public abstract string Id
        {
            get;
            set;
        }

        public abstract string Title
        {
            get;
            set;
        }

        public abstract string Lang
        {
            get;
            set;
        }

        public abstract string Dir
        {
            get;
            set;
        }

        public abstract string ClassName
        {
            get;
            set;
        }
    }
}
