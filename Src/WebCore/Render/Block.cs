using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render
{
    public class Block : Box
    {
        public Block(Node node)
            : base(node)
        {
            
        }

        public int AvailableWidth
        {
            get
            {

                return this.ContentWidth;
            }
        }

        private InlineBoxList lineBoxes;

        public InlineBoxList LineBoxes
        {
            get
            {
                if ( lineBoxes == null )
                {
                    lineBoxes = new InlineBoxList(this);
                }

                return lineBoxes;
            }
        }
    }
}
