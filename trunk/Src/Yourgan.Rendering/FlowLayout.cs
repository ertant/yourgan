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
            PointF location = PointF.Empty;
            RectangleF rectangle = owner.ScrollBounds;

            float maxHeight = 0;

            LayoutMode previousMode = LayoutMode.Block;


            foreach (GraphicObject child in owner.Childs.ToArrayThreadSafe())
            {
                SizeF childSize = child.GetPreferredSize(SizeF.Empty);

                if (
                    (previousMode != child.LayoutMode) ||
                    (child.LayoutMode == LayoutMode.Block) ||
                    ((location.X + childSize.Width > rectangle.Width))
                    )
                {
                    location.X = 0;
                    location.Y += maxHeight;
                    maxHeight = 0;
                }

                switch (child.LayoutMode)
                {
                    case LayoutMode.Block:

                        child.OffsetBounds = new RectangleF(location, this.owner.ScrollBounds.Size);

                        break;

                    case LayoutMode.Inline:

                        child.OffsetBounds = new RectangleF(location, childSize);

                        location.X += childSize.Width;

                        break;
                }

                previousMode = child.LayoutMode;

                if (childSize.Height > maxHeight)
                {
                    maxHeight = childSize.Height;
                }
            }

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
