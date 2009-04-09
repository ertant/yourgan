using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public enum TokenType : int
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DOC")]
        DOCType = 0,
        OpenElement = 1,
        CloseElement = 2,
        Comment = 3,
        Data = 4,
        WhiteSpace = 5,
        Attribute = 6,
        AttributeValue = 7
    }
}
