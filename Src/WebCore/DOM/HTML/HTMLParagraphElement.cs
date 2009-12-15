﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLParagraphElement : HTMLElement
    {
        public HTMLParagraphElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract string Align
        {
            get;
            set;
        }
    }
}
