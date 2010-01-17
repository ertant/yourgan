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
using System;

namespace Yourgan.Core.Render.Style
{
    public class RenderStyle
    {
        public RenderStyle()
        {

        }

        public static RenderStyle Initial
        {
            get
            {
                return new RenderStyle();
            }
        }

        public void InheritFrom(RenderStyle style)
        {
            throw new NotImplementedException();
        }

        private Length Left
        {
            get
            {
                return this.surround.Offset.Left;
            }
            set
            {
                this.surround.Offset.Left = value;
            }
        }

        private Length Top
        {
            get
            {
                return this.surround.Offset.Top;
            }
            set
            {
                this.surround.Offset.Top = value;
            }
        }

        private Length Right
        {
            get
            {
                return this.surround.Offset.Right;
            }
            set
            {
                this.surround.Offset.Right = value;
            }
        }

        private Length Bottom
        {
            get
            {
                return this.surround.Offset.Bottom;
            }
            set
            {
                this.surround.Offset.Bottom = value;
            }
        }

        private BoxData box = new BoxData();

        public Length Width
        {
            get
            {
                return this.box.Width;
            }
        }

        public Length MinWidth
        {
            get
            {
                return this.box.MinWidth;
            }
        }

        public Length MaxWidth
        {
            get
            {
                return this.box.MaxWidth;
            }
        }

        public Length Height
        {
            get
            {
                return this.box.Height;
            }
        }

        public Length MinHeight
        {
            get
            {
                return this.box.MinHeight;
            }
        }

        public Length MaxHeight
        {
            get
            {
                return this.box.MaxHeight;
            }
        }

        private Surround surround = new Surround();

        public Surround Surround
        {
            get
            {
                return surround;
            }
        }

        private PositionStyle position;

        public PositionStyle Position
        {
            get { return position; }
            set { position = value; }
        }

        private DisplayStyle displayStyle;

        public DisplayStyle DisplayStyle
        {
            get { return this.displayStyle; }
            set { this.displayStyle = value; }
        }

        private bool isFloating;

        public bool IsFloating
        {
            get
            {
                return this.isFloating;
            }
            set
            {
                this.isFloating = value;
            }
        }


    }
}
