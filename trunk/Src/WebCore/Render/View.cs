using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Yourgan.Core.DOM;
using Yourgan.Core.Page;
using Yourgan.Core.Render.Style;

namespace Yourgan.Core.Render
{
    public class View : Block
    {
        public View(Node node, FrameView owner)
            : base(node)
        {
            this.owner = owner;
            this.Style.Position = PositionStyle.Absolute;
            this.Layer = new Layer(this);
        }

        private FrameView owner;

        public FrameView Owner
        {
            get
            {
                return owner;
            }
        }

        protected override void OnPaint(Yourgan.Core.Drawing.IGraphicsContext context)
        {
            base.OnPaint(context);

            if (this.IsLayoutInvalid)
            {
                this.PerformLayout();
            }

            context.FillRectangle(System.Drawing.Brushes.Red, this.Frame);
        }

        protected override void OnPerformLayout()
        {
            base.OnPerformLayout();

            

            this.Frame = new Rectangle(0, 0, 50, 50);

            this.UpdateLayout(false);
        }
    }
}
