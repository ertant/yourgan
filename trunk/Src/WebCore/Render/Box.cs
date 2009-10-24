using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yourgan.Core.Render
{
    public class Box : BoxModel
    {
        public Box(Node node)
            : base(node)
        {
        }

        public override bool IsBox
        {
            get
            {
                return true;
            }
        }

        private Rectangle frame;

        public Rectangle Frame
        {
            get
            {
                return frame;
            }
        }

        public int X
        {
            get
            {
                return frame.X;
            }
        }

        public int Y
        {
            get
            {
                return frame.Y;
            }
        }

    }
}
