using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public static class HTMLTagNames
    {
        public const string Html = "HTML";
        public const string Head = "HEAD";
        public const string Title = "TITLE";
        public const string Body = "BODY";

        public static bool IsSame(string localName, string nodeName)
        {
            return string.Equals(localName, nodeName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
