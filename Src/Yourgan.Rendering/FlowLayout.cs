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

        public void PerformLayout()
        {
            PerformLayoutInternal(this.owner, PointF.Empty, this.owner.ScrollWidth);

            isLayoutRequired = false;
        }

        private static void LineFeed(ref PointF location, PointF origin, ref float maxHeight)
        {
            location.X = origin.X;
            location.Y += maxHeight;
            maxHeight = 0;
        }

        private static void PerformLayoutIfRequired(GraphicObject child, PointF location, float scrollWidth)
        {
            ILayoutProvider childLayout = child as ILayoutProvider;

            if (childLayout != null)
            {
                childLayout.Layout.PerformLayoutIfRequired();
            }
            else
            {
                GraphicContainer childContainer = child as GraphicContainer;

                if (childContainer != null)
                {
                    PerformLayoutInternal(childContainer, location, scrollWidth);
                }
            }
        }

        private static void PerformLayoutInternal(GraphicContainer container, PointF offset, float scrollWidth)
        {
            GraphicObject[] childs = container.Childs.ToArrayThreadSafe();

            PointF origin = offset;

            origin.X += container.Style.Margin.Left;
            origin.Y += container.Style.Margin.Top;

            PointF location = offset;

            float maxWidth = 0;
            float maxHeight = 0;

            foreach (GraphicObject child in childs)
            {
                if (child.Style.Display == DisplayMode.Block)
                {
                    LineFeed(ref location, origin, ref maxHeight);
                }

                PerformLayoutIfRequired(child, location, scrollWidth);

                switch (child.Style.Display)
                {
                    case DisplayMode.Block:
                        {
                            child.UpdateOffset(location.X, location.Y);

                            location.Y = child.OffsetTop + child.OffsetHeight;
                            location.X = origin.X;

                            maxHeight = 0;

                            break;
                        }
                    case DisplayMode.Inline:
                        {
                            if (location.X + child.OffsetWidth > container.ScrollWidth)
                            {
                                LineFeed(ref location, origin, ref maxHeight);

                                PerformLayoutIfRequired(child, location, scrollWidth);
                            }

                            child.UpdateOffset(location.X, location.Y);

                            location.X += child.OffsetWidth;

                            if (maxHeight < child.OffsetHeight)
                            {
                                maxHeight = child.OffsetHeight;
                            }

                            break;
                        }
                }

                location.X += child.Style.Padding.Right;
            }

            location.Y += maxHeight;
            location.Y += container.Style.Padding.Bottom;

            if (container.Style.Display == DisplayMode.Block)
            {
                location.X = container.ScrollWidth;
            }

            container.UpdateOffset(offset.X, offset.Y);
            container.UpdateSize(location.X - offset.X, location.Y - offset.Y);
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
