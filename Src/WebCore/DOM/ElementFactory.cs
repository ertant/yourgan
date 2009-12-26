using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class ElementFactory
    {
        public virtual Element Create(QualifiedName qname, Document document)
        {
            return new Element(qname, document);
        }
    }
}
