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
        public FlowLayout(GraphicElement owner)
        {
            this.owner = owner;
        }

        private GraphicElement owner;

        public GraphicElement Owner
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

        private static void LineFeed(GraphicElement container, ref PointF location, PointF origin, ref float maxHeight, bool includeBottom)
        {
            location.X = origin.X;
            location.Y += maxHeight;

            if (includeBottom)
            {
                location.Y += container.Style.Padding.Bottom;
            }

            maxHeight = 0;
        }

        private static void PerformLayoutIfRequired(GraphicNode child, PointF location, float scrollWidth)
        {
            ILayoutProvider childLayout = child as ILayoutProvider;

            if (childLayout != null)
            {
                childLayout.Layout.PerformLayoutIfRequired();
            }
            else
            {
                if (child.Childs.Count > 0)
                {
                    PerformLayoutInternal(child as GraphicElement, location, scrollWidth);
                }
            }
        }

        private static void PerformLayoutInternal(GraphicElement container, PointF offset, float scrollWidth)
        {
            GraphicNode[] childs = container.Childs.ToArrayThreadSafe();

            PointF origin = offset;

            origin.X += container.Style.Margin.Left;
            origin.Y += container.Style.Margin.Top;

            PointF location = origin;

            float maxHeight = 0;
            bool isFirst = true;

            location.Y += container.Style.Padding.Top;

            foreach (GraphicNode node in childs)
            {
                GraphicElement child = node as GraphicElement;

                if (child != null)
                {
                    location.X += container.Style.Padding.Left;
                    //location.Y += container.Style.Padding.Top;

                    if (child.Style.Display == DisplayMode.Block)
                    {
                        LineFeed(container, ref location, origin, ref maxHeight, !isFirst);

                        location.X += container.Style.Padding.Left;
                    }

                    PerformLayoutIfRequired(child, location, scrollWidth);

                    switch (child.Style.Display)
                    {
                        case DisplayMode.Block:
                            {
                                child.UpdateOffset(location.X, location.Y);

                                location.Y = child.OffsetTop + child.OffsetHeight;

                                LineFeed(container, ref location, origin, ref maxHeight, !isFirst);

                                break;
                            }
                        case DisplayMode.Inline:
                            {
                                if (location.X + child.OffsetWidth + container.Style.Padding.Right > container.ScrollWidth - offset.X)
                                {
                                    LineFeed(container, ref location, origin, ref maxHeight, !isFirst);

                                    location.X += container.Style.Padding.Left;

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
                    isFirst = false;
                }
            }

            location.Y += maxHeight;
            location.Y += container.Style.Padding.Bottom;

            if (container.Style.Display == DisplayMode.Block)
            {
                location.X = container.ScrollWidth - offset.X - container.Style.Padding.Right - container.Style.Margin.Right;
            }

            location.Y += container.Style.Margin.Bottom;
            location.X += container.Style.Margin.Right;

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
