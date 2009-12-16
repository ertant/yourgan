// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
using System;
using System.Collections.Generic;

namespace Yourgan.Core.DOM
{
    public class NamedAttributeMap : IEnumerable<Attr>
    {
        private List<Attr> innerCollection;
        protected StringComparer comparer;

        public NamedAttributeMap(Element owner)
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

        private Attr id;

        public Attr Id
        {
            get
            {
                if (id == null)
                {
                    id = UpdateIdAttribute();
                }

                return id;
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
            if ((node.ParentNode != null) && (this.OwnerElement != node.ParentNode))
                throw new DOMException(DOMError.InUseAttribute);

            if ((node.OwnerDocument != null) && (this.OwnerElement.OwnerDocument != node.OwnerDocument))
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
                {
                    this.innerCollection.Remove(existing);
                }

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
                RemoveItem(existing);

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
                RemoveItem(existing);
            }

            return existing;
        }

        public Node RemoveNamedItem(Node node)
        {
            Attr existing = Find(node.LocalName, node.NamespaceURI);

            if (existing != null)
            {
                RemoveItem(existing);
            }

            return existing;
        }

        public Node RemoveNamedItemNS(string namespaceURI, string name)
        {
            Attr existing = Find(name, namespaceURI);

            if (existing != null)
            {
                RemoveItem(existing);
            }

            return existing;
        }

        private void RemoveItem(Attr attr)
        {
            if (attr.IsId)
            {
                this.id = null;
            }

            this.innerCollection.Remove(attr);
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

        internal Attr UpdateIdAttribute()
        {
            // try to scan first user defined id attribute
            foreach (Attr tmpAttr in this.innerCollection)
            {
                if (tmpAttr.IsId)
                {
                    id = tmpAttr;

                    return tmpAttr;
                }
            }

            // second pass for "id" named but not marked as IsId attribute
            foreach (Attr tmpAttr in this.innerCollection)
            {
                if (tmpAttr.UpdateIfIsId())
                {
                    id = tmpAttr;

                    return tmpAttr;
                }
            }

            return null;
        }

        internal void UpdateIdAttribute(Attr newIdAttr)
        {
            this.id = newIdAttr;
        }

        IEnumerator<Attr> IEnumerable<Attr>.GetEnumerator()
        {
            return this.innerCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.innerCollection.GetEnumerator();
        }
    }
}
