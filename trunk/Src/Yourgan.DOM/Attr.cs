using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    // http://www.w3.org/TR/2004/REC-DOM-Level-3-Core-20040407/core.html#ID-637646024
    public interface Attr : Node
    {
        string name
        {
            get;
        }

        bool specified
        {
            get;
        }

        string value
        {
            get;
            set;
        }

        Element ownerElement
        {
            get;
        }

        TypeInfo schemaTypeInfo
        {
            get;
        }

        bool isId
        {
            get;
        }

    }
}
