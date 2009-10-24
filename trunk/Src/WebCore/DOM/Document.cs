using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM
{
    public class Document
    {
        public Document()
        {

        }

        private Node documentElement;

        public Node DocumentElement
        {
            get
            {
                return documentElement;
            }
        }
    }
}
