using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.DOM
{
    public interface HTMLBaseElement : HTMLElement
    {
        string href
        {
            get;
        }

        string target
        {
            get;
        }
    }
}
