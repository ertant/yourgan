﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLPreElement : HTMLElement
    {
        public HTMLPreElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract int Width
        {
            get;
            set;
        }
    }
}