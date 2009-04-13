using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    // http://www.w3.org/TR/2003/REC-DOM-Level-2-HTML-20030109/html.html#ID-58190037
    public interface HTMLElement : Element
    {
        string id
        {
            get;
            set;
        }

        string title
        {
            get;
            set;
        }

        string lang
        {
            get;
            set;
        }

        string className
        {
            get;
            set;
        }
    }
}
