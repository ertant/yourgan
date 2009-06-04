/*
Yourgan
Copyright (C) 2009  Ertan Tike

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yourgan.Rendering
{
    public class FlowLayout : ILayout
    {
        public FlowLayout(GraphicContainer owner)
        {
            this.owner = owner;
        }

        private GraphicContainer owner;

        public GraphicContainer Owner
        {
            get
            {
                return owner;
            }
        }

        public SizeF GetAutoSize(SizeF maxSize)
        {
            return PerformLayoutInternal();
        }

        public void PerformLayout()
        {
            PerformLayoutInternal();
            isLayoutRequired = false;
        }

        private SizeF PerformLayoutInternal()
        {
            GraphicObject[] childs = owner.Childs.ToArrayThreadSafe();

            PointF location = new PointF(this.owner.Style.Margin.Left, this.owner.Style.Margin.Top);

            SizeF scrollSize = this.owner.ScrollBounds.Size;

            float maxHeight = 0;

            DisplayMode previousMode = DisplayMode.Block;
            bool isFirst = true;

            location.Y += this.owner.Style.Padding.Top;

            foreach (GraphicObject child in childs)
            {
                SizeF childSize = child.GetPreferredSize(SizeF.Empty);

                if (!isFirst &&
                        (
                            (previousMode != child.Style.Display) ||
                            (child.Style.Display == DisplayMode.Block) ||
                            ((location.X + childSize.Width > scrollSize.Width))
                        )
                    )
                {
                    location.X = this.owner.Style.Margin.Left;
                    location.Y += maxHeight;
                    maxHeight = 0;

                    location.Y += this.owner.Style.Padding.Top;
                }

                location.X += this.owner.Style.Padding.Left;

                switch (child.Style.Display)
                {
                    case DisplayMode.Block:

                        child.OffsetBounds = new RectangleF(location, new SizeF(scrollSize.Width - this.owner.Style.Padding.Horizontal, childSize.Height));

                        break;

                    case DisplayMode.Inline:

                        child.OffsetBounds = new RectangleF(location, childSize);

                        location.X += childSize.Width;

                        break;
                }

                if (childSize.Height > maxHeight)
                {
                    maxHeight = childSize.Height;
                }

                location.X += this.owner.Style.Padding.Right;

                previousMode = child.Style.Display;
                isFirst = false;
            }

            location.Y += this.owner.Style.Padding.Bottom;

            location.Y += maxHeight;

            return new SizeF(location.X, location.Y);
        }

        private bool isLayoutRequired;

        public bool IsLayoutRequired
        {
            get
            {
                return isLayoutRequired;
            }
        }

        public void Invalidate()
        {
            isLayoutRequired = true;
        }

        public void PerformLayoutIfRequired()
        {
            if (isLayoutRequired)
            {
                this.PerformLayout();
            }
        }
    }
}
