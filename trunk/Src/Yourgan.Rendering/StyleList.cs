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

namespace Yourgan.Rendering
{
    public class StyleList //: IStyle
    {
        public StyleList()
        {
            this.elementStyle = new Style();
        }

        public void AddStyle(Style style)
        {
            throw new NotImplementedException();
        }

        private Style elementStyle;

        public Style ElementStyle
        {
            get
            {
                return elementStyle;
            }
        }

        public Padding Padding
        {
            get
            {
                return this.ElementStyle.Padding;
            }
        }

        public Padding Margin
        {
            get
            {
                return this.ElementStyle.Margin;
            }
        }

        public DisplayMode Display
        {
            get
            {
                return this.ElementStyle.Display;
            }
        }

        public Position Position
        {
            get
            {
                return this.ElementStyle.Position;
            }
        }

        private float width;

        public float Width
        {
            get
            {
                return width;
            }
        }

        public bool HasWidth
        {
            get
            {
                return this.Width > 0;
            }
        }

        private float height;

        public float Height
        {
            get
            {
                return this.height;
            }
        }

        public bool HasHeight
        {
            get
            {
                return this.Height > 0;
            }
        }

    }
}
