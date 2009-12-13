using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class DocumentType : Node
    {
        public DocumentType(Document document, string name, string publicId, string systemId)
            : base(document)
        {
            this.name = name;
            this.publicId = publicId;
            this.systemId = systemId;
        }

        string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public NamedNodeMap Entities
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NamedNodeMap Notations
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string publicId;

        public string PublicId
        {
            get
            {
                return publicId;
            }
        }

        string systemId;

        public string SystemId
        {
            get
            {
                return systemId;
            }
        }

        string internalSubset;

        public string InternalSubset
        {
            get
            {
                return internalSubset;
            }
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.DocumentFragment;
            }
        }

        public override string NodeName
        {
            get
            {
                return this.name;
            }
        }
    }
}
