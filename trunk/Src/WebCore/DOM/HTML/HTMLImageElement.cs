using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLImageElement : HTMLElement
    {
        public HTMLImageElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract string Name
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

        public abstract string Border
        {
            get;
            set;
        }

        public abstract int Height
        {
            get;
            set;
        }

        public abstract int HSpace
        {
            get;
            set;
        }

        public abstract bool IsMap
        {
            get;
            set;
        }

        public abstract string LongDesc
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

        public abstract int VSPace
        {
            get;
            set;
        }

        public abstract int Width
        {
            get;
            set;
        }
    }
}
