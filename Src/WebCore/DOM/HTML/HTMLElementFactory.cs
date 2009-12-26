using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public class HTMLElementFactory : ElementFactory
    {
        private delegate HTMLElement ConstructionHandler(QualifiedName qname, Document document);

        private Dictionary<string, ConstructionHandler> Constructors = new Dictionary<string, ConstructionHandler>(StringComparer.OrdinalIgnoreCase);

        public HTMLElementFactory()
        {
            this.Constructors[HTMLTagNames.Head] = Head;
        }

        #region Constructors

        private static HTMLElement Head(QualifiedName qname, Document document)
        {
            HTMLHeadElement head = new HTMLHeadElement(qname, document);

            return head;
        }

        #endregion

        public override Element Create(QualifiedName qname, Document document)
        {
            ConstructionHandler handler;

            if (Constructors.TryGetValue(qname.LocalName, out handler))
            {
                return handler(qname, document);
            }

            return base.Create(qname, document);
        }
    }
}
