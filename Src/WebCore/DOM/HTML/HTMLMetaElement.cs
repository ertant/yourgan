using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLMetaElement
    {
        public abstract string Content
        {
            get;
            set;
        }

        public abstract string HttpEquiv
        {
            get;
            set;
        }

        public abstract string Name
        {
            get;
            set;
        }

        public abstract string Scheme
        {
            get;
            set;
        }
    }
}
