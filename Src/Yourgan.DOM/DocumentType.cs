using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public interface DocumentType : Node
    {
        string name
        {
            get;
        }

        string publicId
        {
            get;
        }

        string systemId
        {
            get;
        }

        string internalSubset
        {
            get;
        }
    }
}
