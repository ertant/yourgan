using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render.Style
{
    public class Surround
    {
        private LengthBox offset;

        public LengthBox Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        private LengthBox margin;

        public LengthBox Margin
        {
            get { return margin; }
            set { margin = value; }
        }

        private LengthBox padding;

        public LengthBox Padding
        {
            get { return padding; }
            set { padding = value; }
        }

        private Border border;

        public Border Border
        {
            get { return border; }
            set { border = value; }
        }
    }
}
