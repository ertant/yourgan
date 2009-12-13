using System;
using System.Collections.Generic;

namespace Yourgan.Core.DOM
{
    public class NamedNodeMap
    {
        private List<Attr> innerCollection;
        protected StringComparer comparer;

        public NamedNodeMap(Element owner)
        {
            this.ownerElement = owner;

            // TODO : for now HTML asssumed, xml nodes case sensetive. fix here
            this.comparer = StringComparer.CurrentCultureIgnoreCase;
            this.innerCollection = new List<Attr>();
        }

        private Element ownerElement;

        public Element OwnerElement
        {
            get
            {
                return ownerElement;
            }
        }

        public Node this[int index]
        {
            get
            {
                return this.innerCollection[index];
            }
        }

        public int Length
        {
            get
            {
                return this.innerCollection.Count;
            }
        }

        private void CheckValidDocumentAndElement(Node node)
        {
            if ((node.ParentNode != null) || (this.OwnerElement != node.ParentNode))
                throw new DOMException(DOMError.InUseAttribute);

            if ((node.OwnerDocument != null) || (this.OwnerElement.OwnerDocument != node.OwnerDocument))
                throw new DOMException(DOMError.WrongDocument);
        }

        public Node GetNamedItem(string name)
        {
            foreach (Attr node in innerCollection)
            {
                if (string.IsNullOrEmpty(node.Prefix))
                {
                    if (comparer.Compare(name, node.LocalName) == 0)
                        return node;
                }
                else
                {
                    if (comparer.Compare(name, node.NodeName) == 0)
                        return node;
                }
            }

            return null;
        }

        public Node GetNamedItemNS(string namespaceURI, string name)
        {
            return Find(name, namespaceURI);
        }

        public Node SetNamedItem(Node node)
        {
            CheckValidDocumentAndElement(node);

            Attr existing = Find(node.LocalName, string.Empty);

            if (existing != node)
            {
                if (existing != null)
                    this.innerCollection.Remove(existing);

                this.innerCollection.Add(node as Attr);

                return node;
            }

            return null;
        }

        public Node SetNamedItemNS(Node node)
        {
            CheckValidDocumentAndElement(node);

            Attr existing = Find(node.LocalName, node.NamespaceURI);

            if (existing != node)
            {
                if (existing != null)
                    this.innerCollection.Remove(existing);

                this.innerCollection.Add(node as Attr);

                return node;
            }

            return null;
        }

        public Node RemoveNamedItem(string name)
        {
            Attr existing = Find(name, string.Empty);

            if (existing != null)
            {
                this.innerCollection.Remove(existing);
            }

            return existing;
        }

        public Node RemoveNamedItem(Node node)
        {
            Attr existing = Find(node.LocalName, node.NamespaceURI);

            if ( existing != null )
            {
                this.innerCollection.Remove(existing);
            }

            return existing;
        }

        public Node RemoveNamedItemNS(string namespaceURI, string name)
        {
            Attr existing = Find(name, namespaceURI);

            if (existing != null)
            {
                this.innerCollection.Remove(existing);
            }

            return existing;
        }

        private Attr Find(string localName, string namespaceURI)
        {
            // TODO : Prefixleri farkli ama ayni ns'leri gosterenler icin hatali olacak.

            QualifiedName qname = new QualifiedName(null, localName, namespaceURI);

            foreach (Attr attr in innerCollection)
            {
                if (attr.QName.Matches(qname))
                    return attr;
            }

            return null;
        }
    }
}
