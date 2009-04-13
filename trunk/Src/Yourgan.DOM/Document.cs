using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    // http://www.w3.org/TR/2004/REC-DOM-Level-3-Core-20040407/core.html#i-Document
    public interface Document : Node
    {
        Element createElement(string tagName);

        DocumentFragment createDocumentFragment();

        Text createTextNode(string data);

        Comment createComment(string data);

        CDATASection createCDATASection(string data);

        Attr createAttribute(string name);
    }
}
