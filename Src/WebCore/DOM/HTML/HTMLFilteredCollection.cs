using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    class HTMLFilteredCollection : HTMLCollection
    {
        public HTMLFilteredCollection(HTMLElement parent, string xpath)
        {
        }

        public override int Length
        {
            get { throw new NotImplementedException(); }
        }

        public override Node this[int index]
        {
            get { throw new NotImplementedException(); }
        }

        public override Node NamedItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
