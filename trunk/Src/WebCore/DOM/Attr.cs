using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Attr : Node
    {
        public Attr(QualifiedName name, Document document)
            : base(document)
        {
        }

        QualifiedName qname;

        public QualifiedName QName
        {
            get
            {
                return qname;
            }
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.Attribute;
            }
        }

        public override string NodeValue
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public override string NodeName
        {
            get
            {
                return this.Name;
            }
        }

        public string Name
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


        bool specified;

        public bool Specified
        {
            get
            {
                return specified;
            }
        }

        string value;

        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        Element ownerElement;

        public Element OwnerElement
        {
            get
            {
                return ownerElement;
            }
        }

        internal void SetOwnerElement(Element owner)
        {
            this.ownerElement = owner;
        }

        public bool IsId
        {
            get
            {
                return this.LocalName.Equals("id", StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
