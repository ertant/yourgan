using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Yourgan.Core.UI;

namespace Yourgan.Core.Page
{
    public class FrameView : ScrollView
    {
        public FrameView(Frame frame)
        {
            this.frame = frame;
        }

        private Frame frame;

        public Frame Frame
        {
            get { return frame; }
        }

        public int LayoutWidth
        {
            get
            {
                return this.VisibleWidth;
            }
        }

        public int LayoutHeight
        {
            get
            {
                return this.LayoutHeight;
            }
        }
    }
}
