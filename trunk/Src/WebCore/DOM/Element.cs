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
    }
}
