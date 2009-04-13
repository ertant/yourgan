using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    // http://www.w3.org/TR/2003/REC-DOM-Level-2-HTML-20030109/html.html#ID-79243169
    public interface HTMLTitleElement : HTMLElement
    {
        string text
        {
            get;
        }
    }
}
