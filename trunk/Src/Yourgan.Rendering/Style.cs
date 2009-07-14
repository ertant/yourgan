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

namespace Yourgan.Rendering
{
    public class Style
    {
        public Style()
        {
            this.display = DisplayMode.Block;
            this.position = Position.Inherit;
            this.padding = new Padding(1);
            this.margin = new Padding(2);
        }

        private Padding padding;

        public Padding Padding
        {
            get
            {
                return padding;
            }
            set
            {
                padding = value;
            }
        }

        private Padding margin;

        public Padding Margin
        {
            get
            {
                return margin;
            }
            set
            {
                margin = value;
            }
        }

        private DisplayMode display;

        public DisplayMode Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
            }
        }

        private Position position;

        public Position Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        string width = "";

        public string Width
        {
            get
            {
                return width;
            }
        }


    }
}
