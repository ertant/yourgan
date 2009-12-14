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
                return NodeType.DocumentType;
            }
        }

        public override string NodeName
        {
            get
            {
                return this.name;
            }
        }

        public override string TextContent
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
    }
}
