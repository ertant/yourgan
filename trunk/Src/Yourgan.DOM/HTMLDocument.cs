using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    // http://www.w3.org/TR/2003/REC-DOM-Level-2-HTML-20030109/html.html#ID-26809268
    public interface HTMLDocument : Document
    {
        string title
        {
            get;
            set;
        }

        string URL
        {
            get;
        }


        HTMLHead head
        {
            get;
        }

        HTMLBody body
        {
            get;
        }

        NodeList getElementsByName(string elementName);
    }
}
