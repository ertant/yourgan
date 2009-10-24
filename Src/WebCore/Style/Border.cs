using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Style
{
    public class Border
    {
        public Border()
        {
        }

        private BorderValue left = new BorderValue();

        public BorderValue Left
        {
            get { return left; }
        }

        private BorderValue top = new BorderValue();

        public BorderValue Top
        {
            get { return top; }
        }

        private BorderValue right = new BorderValue();

        public BorderValue Right
        {
            get { return right; }
        }

        private BorderValue bottom = new BorderValue();

        public BorderValue Bottom
        {
            get { return bottom; }
        }

        public bool HasBorder
        {
            get
            {
                return !this.left.IsZero || !this.top.IsZero || !this.right.IsZero || !this.bottom.IsZero;
            }
        }
    }
}
