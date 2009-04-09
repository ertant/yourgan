using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public class ParseException : Exception
    {
        public ParseException()
        {
        }

        public ParseException(string message)
            : base(message)
        {
        }
    }
}
