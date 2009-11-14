using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Yourgan.Core.Drawing;

namespace Yourgan.Core.Page
{
    public class Page
    {
        public Page()
        {
            this.mainFrame = new Frame(this);
        }

        private Frame mainFrame;

        public Frame MainFrame
        {
            get { return mainFrame; }
        }

        private IHostWindow hostWindow;

        public IHostWindow HostWindow
        {
            get
            {
                return hostWindow;
            }
            set
            {
                hostWindow = value;

                hostWindow.SizeChanged += delegate(object sender, EventArgs e)
                                              {
                                                  this.ResetVisibleBounds();
                                                  this.Paint();
                                              };
                this.ResetVisibleBounds();
            }
        }

        private void ResetVisibleBounds()
        {
            this.MainFrame.View.VisibleBounds = new Rectangle(new Point(0, 0), hostWindow.Size);
            this.MainFrame.View.UpdateLayout(true);
        }

        public void Paint()
        {
            if (this.MainFrame.View.IsLayoutInvalid)
            {
                this.MainFrame.View.PerformLayout();
            }

            this.HostWindow.Platform.Reset(this.MainFrame.View.Bounds.Size);

            this.MainFrame.Renderer.Paint(this.HostWindow.Platform.Current);
        }
    }
}
