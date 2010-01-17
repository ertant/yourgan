// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
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
            //context.FillRectangle(Brushes.Red, this.Frame);
        }

        protected virtual void UpdateWidth(LayoutContext context)
        {
            Length w = this.Style.Width;

            int availableWidth = this.ContainingBlock.AvailableWidth;

            int newWidth = w.Calculate(availableWidth);          

            if (this.Style.MaxWidth.IsDefined)
            {
                int maxWidth = this.Style.MaxWidth.Calculate(availableWidth);

                if (newWidth > maxWidth)
                    newWidth = maxWidth;
            }

            if (this.Style.MinWidth.IsDefined)
            {
                int minWidth = this.Style.MinWidth.Calculate(availableWidth);

                if (newWidth < minWidth)
                    newWidth = minWidth;
            }



            // TODO : 
            // this.Frame.Width = newWidth;

            // RenderBlock.cpp : 4011
        }

        protected virtual void UpdateHeight(LayoutContext context)
        {
            Length h = this.Style.Height;

            
        }
    }
}
