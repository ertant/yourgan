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
namespace Yourgan.Core.Render.Style
{
    public class BorderValue
    {
        public BorderValue()
        {
            this.color = Color.Transparent;
            this.width = 0;
            this.style = BorderStyle.None;
        }

        private Color color;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private int width;

        public int Width
        {
            get
            {
                return width;
            }
        }

        private BorderStyle style;

        public BorderStyle Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
            }
        }

        public bool IsZero
        {
            get
            {
                return (this.width != 0);
            }
        }

        public bool IsVisible
        {
            get
            {
                return (this.style != BorderStyle.Hidden) && (this.style != BorderStyle.None);
            }
        }

        public int GetWidth()
        {
            if (this.IsVisible)
            {
                return this.Width;
            }
            else
            {
                return 0;
            }
        }
    }
}
