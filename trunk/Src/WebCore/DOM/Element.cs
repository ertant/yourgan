using System;
using System.Collections.Generic;
using System.Linq;
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

        public override NamedNodeMap Attributes
        {
            get
            {
                throw new NotImplementedException();
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

        #endregion

        #endregion
    }
}
