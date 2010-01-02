using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class ElementFactory
    {
        public virtual T Create<T>(QualifiedName qname, Document document) where T : Element
        {
            return new Element(qname, document) as T;
        }
    }
}
