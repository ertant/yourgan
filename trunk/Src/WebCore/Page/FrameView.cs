using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yourgan.Core.Page
{
    abstract class FrameView
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

        public abstract Rectangle Bounds
        {
            get;
        }

        public int Width
        {
            get
            {
                return this.Bounds.Width;
            }
        }

        public int Height
        {
            get
            {
                return this.Bounds.Height;
            }
        }

        public Rectangle VisibleContent
        {
            get
            {
                // TODO : Add scrollbars
                return this.Bounds;
            }
        }

        public int VisibleWidth
        {
            get
            {
                return this.VisibleContent.Width;
            }
        }

        public int VisibleHeight
        {
            get
            {
                return this.VisibleContent.Height;
            }
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
