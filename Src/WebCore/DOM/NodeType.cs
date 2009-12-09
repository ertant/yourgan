using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public enum NodeType : int
    {
        Element = 1,
        Attribute = 2,
        Text = 3,
        CData = 4,
        EntityReference = 5,
        EntityNode = 6,
        ProcessingInstruction = 7,
        Comment = 8,
        Document  = 9,
        DocumentType = 10,
        DocumentFragment = 11,
        Notation = 12,
        XPathNamespace = 13
    }
}
