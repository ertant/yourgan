using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Attr : Node
    {
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
                return this.name;
            }
        }

        string name;

        public string Name
        {
            get
            {
                return name;
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

        public bool IsId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
