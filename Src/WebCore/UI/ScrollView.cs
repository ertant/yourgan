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

namespace Yourgan.Core.UI
{
    public abstract class ScrollView : Widget
    {
        protected ScrollView()
        {
            this.horizontalScrollbar = new Scrollbar();
            this.horizontalScrollbar.ValueChanged += this.ScrollbarChanged;

            this.verticalScrollbar = new Scrollbar();
            this.verticalScrollbar.ValueChanged += this.ScrollbarChanged;
        }

        private ScrollbarMode horizontalScrollbarMode;

        public ScrollbarMode HorizontalScrollbarMode
        {
            get { return this.horizontalScrollbarMode; }
            set { this.horizontalScrollbarMode = value; }
        }

        private ScrollbarMode verticalScrollbarMode;

        public ScrollbarMode VerticalScrollbarMode
        {
            get { return this.verticalScrollbarMode; }
            set { this.verticalScrollbarMode = value; }
        }

        private Scrollbar horizontalScrollbar;

        public Scrollbar HorizontalScrollbar
        {
            get { return this.horizontalScrollbar; }
        }

        private Scrollbar verticalScrollbar;

        public Scrollbar VerticalScrollbar
        {
            get { return this.verticalScrollbar; }
        }

        public Point ScrollPosition
        {
            get
            {
                return this.visibleBounds.Location;
            }
            set
            {
                this.VisibleBounds = new Rectangle(value, this.ScrollSize);
            }
        }

        public Size ScrollSize
        {
            get
            {
                return this.visibleBounds.Size;
            }
            set
            {
                this.VisibleBounds = new Rectangle(this.ScrollPosition, value);
            }
        }

        private Rectangle visibleBounds;

        public Rectangle VisibleBounds
        {
            get
            {
                return visibleBounds;
            }
            set
            {
                visibleBounds = value;

                dismissEvents = true;

                // Update scrollbars
                this.horizontalScrollbar.Value = value.X;
                this.verticalScrollbar.Value = value.Y;

                this.horizontalScrollbar.Maximum = value.Width;
                this.verticalScrollbar.Maximum = value.Height;

                dismissEvents = false;
            }
        }

        public int VisibleWidth
        {
            get
            {
                return this.visibleBounds.Width;
            }
        }

        public int VisibleHeight
        {
            get
            {
                return this.visibleBounds.Height;
            }
        }

        private bool dismissEvents = false;

        private void ScrollbarChanged(object sender, ScrollbarValueChangeEventArgs e)
        {
            if (!dismissEvents)
            {
                if (e.Scrollbar == this.horizontalScrollbar)
                {
                    this.ScrollPosition = new Point(e.Value, this.visibleBounds.Y);
                }
                else if (e.Scrollbar == this.verticalScrollbar)
                {
                    this.ScrollPosition = new Point(this.visibleBounds.X, e.Value);
                }
            }
        }
    }
}
