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

namespace Yourgan.Core.DOM
{
    public class Attr : Node
    {
        public Attr(QualifiedName qname, Document document)
            : base(document)
        {
            if (qname == null)
                throw new ArgumentNullException("qname");

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
