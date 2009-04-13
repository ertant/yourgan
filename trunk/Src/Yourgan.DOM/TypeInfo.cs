using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public interface TypeInfo
    {
        string typeName
        {
            get;
        }

        string typeNamespace
        {
            get;
        }

        bool isDerivedFrom(string typeNamespaceArg, string typeNameArg, uint derivationMethod);
    }
}
