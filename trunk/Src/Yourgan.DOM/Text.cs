using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public interface Text
    {
        Text splitText(uint offset);

        bool isElementContentWhitespace
        {
            get;
        }

        string wholeText
        {
            get;
        }

        Text replaceWholeText(string content);
    }
}
