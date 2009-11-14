using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render.Style
{
    public class BoxData
    {
        private Length width;

        public Length Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        private Length height;

        public Length Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        private Length minWidth;

        public Length MinWidth
        {
            get
            {
                return minWidth;
            }
            set
            {
                minWidth = value;
            }
        }

        private Length minHeight;

        public Length MinHeight
        {
            get
            {
                return minHeight;
            }
            set
            {
                minHeight = value;
            }
        }


        private Length maxWidth;

        public Length MaxWidth
        {
            get
            {
                return maxWidth;
            }
            set
            {
                maxWidth = value;
            }
        }

        private Length maxHeight;

        public Length MaxHeight
        {
            get
            {
                return maxHeight;
            }
            set
            {
                maxHeight = value;
            }
        }
    }
}
