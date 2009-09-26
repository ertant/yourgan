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
using System.Threading;

namespace Yourgan.Rendering
{
    public class FlowLayout : ILayout
    {
        private Thread layoutThread;

        public FlowLayout(GraphicElement owner)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");

            this.owner = owner;

            layoutThread = new Thread(new ThreadStart(PerformLayoutLoop));
            layoutThread.IsBackground = true;
            layoutThread.Start();
        }

        ~FlowLayout()
        {
            layoutThread.Abort();
        }

        private GraphicElement owner;

        public GraphicElement Owner
        {
            get
            {
                return owner;
            }
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

        private static void PerformLayoutIfRequired(GraphicNode child, PointF location)
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
                    PerformLayoutInternal(child as GraphicElement, location);
                }
            }
        }

        private static void PerformLayoutInternal(GraphicElement container, PointF offset)
        {
            GraphicNode[] childs = container.Childs.ToArrayThreadSafe();

            PointF origin = offset;

            origin.X += container.Style.Margin.Left;
            origin.Y += container.Style.Margin.Top;

            PointF location = origin;

            float maxHeight = 0;
            float maxWidth = 0;
            bool isFirst = true;

            float scrollWidth = container.ScrollWidth - container.OffsetLeft;

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

                    PerformLayoutIfRequired(child, location);

                    float childWidth = child.OffsetWidth;
                    float childHeight = child.OffsetHeight;

                    switch (child.Style.Display)
                    {
                        case DisplayMode.Block:
                            {
                                child.UpdateOffset(location.X, location.Y);

                                location.Y = child.OffsetTop + childHeight;

                                LineFeed(container, ref location, origin, ref maxHeight, !isFirst);

                                break;
                            }
                        case DisplayMode.Inline:
                            {
                                if (childWidth + container.Style.Padding.Right > scrollWidth - location.X)
                                {
                                    LineFeed(container, ref location, origin, ref maxHeight, !isFirst);

                                    location.X += container.Style.Padding.Left;

                                    PerformLayoutIfRequired(child, location);

                                    childWidth = child.OffsetWidth;
                                    childHeight = child.OffsetHeight;
                                }

                                child.UpdateOffset(location.X, location.Y);

                                location.X += childWidth;

                                if (maxWidth < childWidth)
                                {
                                    maxWidth = childWidth;
                                }

                                if (maxHeight < childHeight)
                                {
                                    maxHeight = childHeight;
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
            location.Y += container.Style.Margin.Bottom;

            if (container.Style.Display == DisplayMode.Block)
            {
                location.X = scrollWidth - container.Style.Padding.Horizontal;
            }
            else
            {
                if (location.X < maxWidth)
                {
                    location.X = maxWidth;
                }

                location.X += container.Style.Margin.Right;
            }

            container.UpdateOffset(offset.X, offset.Y);
            container.UpdateSize(location.X - offset.X, location.Y - offset.Y);
        }

        private int invalidateCount;

        public bool IsLayoutRequired
        {
            get
            {
                return invalidateCount > 0;
            }
        }

        public void Invalidate()
        {
            Interlocked.Increment(ref invalidateCount);
        }

        public void PerformLayout()
        {
            PerformLayoutInternal(this.owner, PointF.Empty);
        }

        public bool PerformLayoutIfRequired()
        {
            bool invalidated = false;

            while (invalidateCount > 0)
            {
                this.PerformLayout();

                Interlocked.Decrement(ref invalidateCount);

                invalidated = true;
            }

            return invalidated;
        }

        private void PerformLayoutLoop()
        {
            while (true)
            {
                if (PerformLayoutIfRequired())
                {
                    this.owner.OwnerDocument.DefaultView.InvalidatePaint();
                }

                Thread.Sleep(10);
            }
        }
    }
}
