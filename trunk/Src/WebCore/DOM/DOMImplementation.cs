using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            Document document = new Document(null);

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
