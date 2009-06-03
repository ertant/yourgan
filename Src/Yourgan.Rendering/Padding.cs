using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Rendering
{
    public class Padding
    {
        private bool all;

        public float All
        {
            get
            {
                if (all)
                    return this.top;
                else
                    return -1;
            }
            set
            {
                this.top = value;
                all = false;
            }
        }

        private float left;

        public float Left
        {
            get
            {
                if (all)
                    return this.top;
                else
                    return left;
            }
            set
            {
                left = value;
                all = false;
            }
        }

        private float right;

        public float Right
        {
            get
            {
                if (all)
                    return this.top;
                else
                    return right;
            }
            set
            {
                right = value;
                all = false;
            }
        }

        private float top;

        public float Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

        private float bottom;

        public float Bottom
        {
            get
            {
                if (all)
                    return this.top;
                else
                    return bottom;
            }
            set
            {
                bottom = value;
                all = false;
            }
        }
    }
}
