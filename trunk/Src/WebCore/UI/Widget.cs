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
    public class Widget
    {
        public Widget()
        {
        }

        private ScrollView parent;

        public ScrollView Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        private INativeWidget nativeWidget;

        public INativeWidget NativeWidget
        {
            get
            {
                return nativeWidget;
            }
            set
            {
                nativeWidget = value;
            }
        }

        private Rectangle bounds;

        public Rectangle Bounds
        {
            get
            {
                return bounds;
            }
            set
            {
                bounds = value;
            }
        }

        public int Width
        {
            get
            {
                return this.Bounds.Width;
            }
        }

        public int Height
        {
            get
            {
                return this.Bounds.Height;
            }
        }

        public Size Size
        {
            get
            {
                return this.Bounds.Size;
            }
        }
    }
}
