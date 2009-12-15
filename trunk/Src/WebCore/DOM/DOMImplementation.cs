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
    public class DOMImplementation
    {
        public bool HasFeature(string feature, string version)
        {
            throw new NotImplementedException();
        }

        public DocumentType CreateDocumentType(string qualifiedName, string publicId, string systemId)
        {
            DocumentType type = new DocumentType(null, qualifiedName, publicId, systemId);

            return type;
        }

        public Document CreateDocument(string namespaceURI, string qualifiedName, DocumentType docType)
        {
            if ((docType != null) && (docType.OwnerDocument != null))
                throw new DOMException(DOMError.WrongDocument);

            Document document = new Document();

            if (docType != null)
            {
                document.AppendChild(docType);
            }

            if (!string.IsNullOrEmpty(namespaceURI))
            {
                Element element = document.CreateElementNS(namespaceURI, qualifiedName);

                document.AppendChild(element);
            }

            return document;
        }

        public object GetFeature(string feature, string version)
        {
            throw new NotImplementedException();
        }
    }
}
