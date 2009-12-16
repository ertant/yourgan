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
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Element : Node
    {
        public Element(QualifiedName qname, Document document)
            : base(document)
        {
            this.qname = qname;
        }

        QualifiedName qname;

        public QualifiedName QName
        {
            get
            {
                return qname;
            }
        }

        #region DOM

        private NamedAttributeMap attributes;

        public override NamedAttributeMap Attributes
        {
            get
            {
                if (attributes == null)
                    attributes = new NamedAttributeMap(this);

                return attributes;
            }
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.Element;
            }
        }

        public override string NodeName
        {
            get
            {
                return this.TagName;
            }
        }

        public string TagName
        {
            get
            {
                return qname.ToString();
            }
        }

        public override string LocalName
        {
            get
            {
                return qname.LocalName;
            }
        }

        public override string NamespaceURI
        {
            get
            {
                return qname.NamespaceURI;
            }
        }

        public override string Prefix
        {
            get
            {
                return qname.Prefix;
            }
            set
            {
                // TODO : is this right ?
                this.qname = new QualifiedName(value, this.LocalName, this.NamespaceURI);
            }
        }

        public override bool HasAttributes()
        {
            return (this.Attributes != null) && (this.Attributes.Length > 0);
        }

        protected override bool IsValidChildType(NodeType type)
        {
            switch (type)
            {
                case NodeType.Attribute:
                case NodeType.CData:
                case NodeType.Comment:
                case NodeType.Element:
                case NodeType.EntityReference:
                case NodeType.ProcessingInstruction:
                case NodeType.Text:
                    return true;
                default:
                    return false;
            }
        }

        protected internal override void OnChildAdded(Node node)
        {
            base.OnChildAdded(node);

            Attr attr = node as Attr;

            if (attr != null)
            {
                attr.SetOwnerElement(this);
            }
        }

        protected internal override void OnChildRemoved(Node node)
        {
            base.OnChildRemoved(node);

            Attr attr = node as Attr;

            if (attr != null)
            {
                attr.SetOwnerElement(null);
            }
        }

        #region Attributes

        public string GetAttribute(string name)
        {
            Node attr = this.Attributes.GetNamedItem(name);

            if (attr != null)
            {
                return attr.NodeValue;
            }

            return null;
        }

        public string GetAttributeNS(string namespaceURI, string localname)
        {
            Node attr = this.Attributes.GetNamedItemNS(namespaceURI, localname);

            if (attr != null)
            {
                return attr.NodeValue;
            }

            return null;
        }

        public void SetAttribute(string name, string value)
        {
            Node attr = this.Attributes.GetNamedItem(name);

            if (attr != null)
            {
                attr.NodeValue = value;
            }
            else
            {
                attr = this.OwnerDocument.CreateAttribute(name);

                attr.NodeValue = value;

                this.Attributes.SetNamedItem(attr);
            }
        }

        public void SetAttributeNS(string namespaceURI, string localname, string value)
        {
            Node attr = this.Attributes.GetNamedItemNS(namespaceURI, localname);

            if (attr != null)
            {
                attr.NodeValue = value;
            }
            else
            {
                attr = this.OwnerDocument.CreateAttributeNS(namespaceURI, localname);

                attr.NodeValue = value;

                this.Attributes.SetNamedItem(attr);
            }
        }

        public void RemoveAttribute(string name)
        {
            this.Attributes.RemoveNamedItem(name);
        }

        public void RemoveAttributeNS(string namespaceURI, string localname)
        {
            this.Attributes.RemoveNamedItemNS(namespaceURI, localname);
        }

        public Attr GetAttributeNode(string name)
        {
            return this.Attributes.GetNamedItem(name) as Attr;
        }

        public Attr GetAttributeNodeNS(string namespaceURI, string localname)
        {
            return this.Attributes.GetNamedItemNS(namespaceURI, localname) as Attr;
        }

        public Attr SetAttributeNode(Attr attr)
        {
            return this.Attributes.SetNamedItem(attr) as Attr;
        }

        public Attr SetAttributeNodeNS(Attr attr)
        {
            return this.Attributes.SetNamedItemNS(attr) as Attr;
        }

        public void RemoveAttributeNode(Attr old)
        {
            this.Attributes.RemoveNamedItem(old);
        }

        public bool HasAttribute(string name)
        {
            Attr attr = this.Attributes.GetNamedItem(name) as Attr;

            return attr != null;
        }

        public bool HasAttributeNS(string namespaceURI, string localname)
        {
            Attr attr = this.Attributes.GetNamedItemNS(namespaceURI, localname) as Attr;

            return attr != null;
        }

        private Attr GetIdAttributeNode()
        {
            foreach (Attr attr in this.Attributes)
                if (attr.IsId)
                    return attr;

            return null;
        }

        public void SetIdAttribute(string name, bool isId)
        {
            Attr attr = this.GetAttributeNode(name);

            SetIdAttributeNode(attr, isId);
        }

        public void SetIdAttributeNS(string namespaceURI, string localName, bool isId)
        {
            Attr attr = this.GetAttributeNodeNS(namespaceURI, localName);

            SetIdAttributeNode(attr, isId);
        }

        public void SetIdAttributeNode(Attr attr, bool isId)
        {
            if (attr == null)
                throw new DOMException(DOMError.NotFound);

            if (attr.OwnerElement != this)
                throw new DOMException(DOMError.NotFound);

            if (isId)
            {
                // update previous
                Attr id = this.GetIdAttributeNode();

                if (id != null)
                {
                    id.IsId = false;
                }

                attr.IsId = true;
            }
            else
            {
                attr.IsId = false;

                foreach (Attr tmpAttr in this.Attributes)
                {
                    if (tmpAttr.UpdateIfIsId())
                    {
                        break;
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}
