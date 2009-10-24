using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Yourgan.Rendering.WindowsForms.Test
{
    public class Panel : System.Windows.Forms.ScrollableControl
    {
        public Panel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);

            this.AutoScrollMinSize = new Size(4000, 4000);
        }

        private Window window;

        [System.ComponentModel.DefaultValue(null)]
        public Window Window
        {
            get
            {
                return window;
            }
            set
            {
                window = value;

                if (window != null)
                {
                    window.Size = this.ClientRectangle;
                    window.Change += UpdatePanel;
                }

                Invalidate();
            }
        }

        private delegate void UpdatePanelHandler();

        private void UpdatePanel()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdatePanelHandler(UpdatePanel));
            }
            else if ((window.Document.DocumentElement != null) && (window.Document.DocumentElement.Body != null))
            {
                this.Invalidate();
            }
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);

            if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                this.window.Document.DocumentElement.Body.ScrollLeft = se.NewValue;

                this.Invalidate();
            }
            else
            {
                this.window.Document.DocumentElement.Body.ScrollTop = se.NewValue;

                this.Invalidate();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            Point p = this.AutoScrollPosition;

            p.Y += e.Delta;

            this.AutoScrollPosition = p;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (window != null)
            {
                window.Size = this.ClientRectangle;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if ( this.DesignMode)
            {
                base.OnPaintBackground(pevent);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (window != null)
            {
                DrawingContext drawingContext = new DrawingContext(e.Graphics);

                window.Paint(drawingContext);
            }
        }
    }
}
