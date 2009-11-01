using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.Render;
using Yourgan.Core.Style;

namespace Yourgan.Core.DOM
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
            protected set
            {
                document = value;
            }
        }

        private Primitive renderer;

        public Primitive Renderer
        {
            get
            {
                return renderer;
            }
            protected set
            {
                renderer = value;
            }
        }

        public StyleData GetStyle()
        {
            return null;
        }
    }
}
