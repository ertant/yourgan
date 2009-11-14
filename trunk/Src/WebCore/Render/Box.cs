using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Yourgan.Core.DOM;

namespace Yourgan.Core.Render
{
    public class Box : BoxModel
    {
        public Box(Node node)
            : base(node)
        {
        }

        public override bool IsBox
        {
            get
            {
                return true;
            }
        }

        private Rectangle frame;

        public Rectangle Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
            }
        }

        public int X
        {
            get
            {
                return frame.X;
            }
        }

        public int Y
        {
            get
            {
                return frame.Y;
            }
        }

        public int Width
        {
            get
            {
                return frame.Width;
            }
        }

        public int Height
        {
            get
            {
                return frame.Height;
            }
        }

        public int ClientWidth
        {
            get
            {
                // TODO : Scrollbar width
                return Width - this.BorderLeft - this.BorderRight;
            }
        }

        public int ClientHeight
        {
            get
            {
                // TODO : Scrollbar height
                return this.Height - this.BorderTop - this.BorderBottom;
            }
        }

        public int ContentWidth
        {
            get
            {
                return this.ClientWidth - PaddingLeft - PaddingRight;
            }
        }

        public int ContentHeight
        {
            get
            {
                return this.ClientHeight - PaddingTop - PaddingBottom;
            }
        }

        private PrimitiveList childs;

        public PrimitiveList Childs
        {
            get
            {
                if (childs == null)
                {
                    childs = new PrimitiveList(this);
                }

                return childs;
            }
        }


        protected override void OnPaint(Yourgan.Core.Drawing.IGraphicsContext context)
        {
            context.FillRectangle(Brushes.Red, this.Frame);
        }
    }
}
