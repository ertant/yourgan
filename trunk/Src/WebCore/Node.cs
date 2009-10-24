using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core
{
    public class Node
    {
        public Node(Document document)
        {
            this.document = document;
        }

        private Document document;

        public Document Document
        {
            get
            {
                return document;
            }
        }
    }
}
