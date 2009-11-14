using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Yourgan.Core.UI;
using Yourgan.Core.Render;

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
                return this.VisibleHeight;
            }
        }

        public Box ContentRenderer
        {
            get
            {
                if (this.Frame.Document != null)
                {
                    return this.Frame.Document.Renderer as Box;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsLayoutInvalid
        {
            get
            {
                if (this.ContentRenderer != null)
                    return this.ContentRenderer.IsLayoutInvalid;
                else
                    return false;
            }
        }

        public void PerformLayout()
        {
            if ((this.ContentRenderer != null) && (this.ContentRenderer.IsLayoutInvalid))
            {
                this.ContentRenderer.PerformLayout();

                this.Bounds = this.ContentRenderer.Frame;
            }
        }

        public void UpdateLayout(bool isInvalid)
        {
            if (this.ContentRenderer != null)
            {
                this.ContentRenderer.UpdateLayout(isInvalid);
            }
        }
    }
}
