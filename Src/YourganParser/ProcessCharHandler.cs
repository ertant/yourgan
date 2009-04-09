using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public unsafe delegate void ProcessCharHandler(TagTokenizerState state, char* c);
}
