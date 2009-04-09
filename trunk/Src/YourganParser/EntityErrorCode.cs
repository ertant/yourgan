using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public enum EntityErrorCode
    {
        DocTypeUnexpected,
        UnexpectedEndTag,
        TagIsNotSelfClosed,
        HeadUnexpected,
        UnexpectedStartTag,
        UnexpectedTag
    }
}
