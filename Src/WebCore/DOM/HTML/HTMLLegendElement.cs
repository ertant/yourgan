using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLLegendElement : HTMLElement
    {
        public abstract HTMLFormElement Form
        {
            get;
        }

        public abstract string AccessKey
        {
            get;
            set;
        }

        public abstract string Align
        {
            get;
            set;
        }
    }
}
