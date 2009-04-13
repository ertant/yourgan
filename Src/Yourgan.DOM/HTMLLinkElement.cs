using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public interface HTMLLinkElement : HTMLElement
    {
        string href
        {
            get;
        }

        string rel
        {
            get;
        }

        string media
        {
            get;
        }

        string hreflang
        {
            get;
        }

        string type
        {
            get;
        }

        string sizes
        {
            get;
        }
    }
}
