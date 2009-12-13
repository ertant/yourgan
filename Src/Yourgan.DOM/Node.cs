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
namespace Yourgan.DOM
{
    // http://www.w3.org/TR/2004/REC-DOM-Level-3-Core-20040407/core.html#ID-1950641247
    public interface Node
    {
        string nodeName
        {
            get;
        }

        string nodeValue
        {
            get;
            set;
        }

        string localName
        {
            get;
        }

        bool hasAttributes
        {
            get;
        }

        string baseURI
        {
            get;
        }

        System.Xml.XmlNodeType nodeType
        {
            get;
        }

        Node parentNode
        {
            get;
        }

        NodeList childNodes
        {
            get;
        }

        Node firstChild
        {
            get;
        }

        Node lastChild
        {
            get;
        }

        Node previousSibling
        {
            get;
        }

        Node nextSibling
        {
            get;
        }

        NamedNodeMap attributes
        {
            get;
        }

        Document ownerDocument
        {
            get;
        }

        Node insertBefore(Node newChild, Node refChild);

        Node replaceChild(Node newChild, Node oldChild);

        Node removeChild(Node oldChild);

        Node appendChild(Node newChild);

        bool hasChildNodes();

        Node cloneNode(bool deep);

        void normalize();

        bool isSupported(string feature, string version);

        string namespaceURI
        {
            get;
        }
        string prefix
        {
            get;
        }

        DocumentPosition compareDocumentPosition(Node other);

        string textContent
        {
            get;
            set;
        }

        bool isSameNode(Node other);

        string lookupPrefix(string namespaceURI);

        bool isDefaultNamespace(string namespaceURI);

        string lookupNamespaceURI(string prefix);

        bool isEqualNode(Node arg);

        /*
        DOMObject getFeature(string feature, string version);

        DOMUserData setUserData(string key, DOMUserData data, UserDataHandler handler);

        DOMUserData getUserData(string key);
        */
    }
}
