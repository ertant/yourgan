using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core
{
    public class LengthBox
    {
        private Length left;

        public Length Left
        {
            get { return left; }
            set { left = value; }
        }

        private Length top;

        public Length Top
        {
            get { return top; }
            set { top = value; }
        }

        private Length right;

        public Length Right
        {
            get { return right; }
            set { right = value; }
        }

        private Length bottom;

        public Length Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        public bool IsZero()
        {
            return this.left.IsZero() && this.top.IsZero() && this.right.IsZero() && this.bottom.IsZero();
        }
    }
}
