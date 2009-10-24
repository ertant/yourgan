using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.DOM;
using Yourgan.Core.Page;

namespace Yourgan.Core.Render
{
    public class View : Block
    {
        public View(Node node, FrameView owner)
            : base(node)
        {
            this.owner = owner;
        }

        private FrameView owner;

        public FrameView Owner
        {
            get
            {
                return owner;
            }
        }
    }
}
