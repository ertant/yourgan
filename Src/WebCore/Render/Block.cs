using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.DOM;

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

        private LineBoxList lineBoxes;

        public LineBoxList LineBoxes
        {
            get
            {
                if ( lineBoxes == null )
                {
                    lineBoxes = new LineBoxList();
                }

                return lineBoxes;
            }
        }
    }
}
