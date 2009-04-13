using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public interface NamedNodeMap
    {
        Node getNamedItem(string name);

        Node setNamedItem(Node arg);

        Node removeNamedItem(string name);

        Node item(uint index);

        uint length
        {
            get;
        }

        Node getNamedItemNS(string namespaceURI, string localName);

        Node setNamedItemNS(Node arg);

        Node removeNamedItemNS(string namespaceURI, string localName);
    }
}
