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
    public class BoxData
    {
        private Length width;

        public Length Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        private Length height;

        public Length Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        private Length minWidth;

        public Length MinWidth
        {
            get
            {
                return minWidth;
            }
            set
            {
                minWidth = value;
            }
        }

        private Length minHeight;

        public Length MinHeight
        {
            get
            {
                return minHeight;
            }
            set
            {
                minHeight = value;
            }
        }


        private Length maxWidth;

        public Length MaxWidth
        {
            get
            {
                return maxWidth;
            }
            set
            {
                maxWidth = value;
            }
        }

        private Length maxHeight;

        public Length MaxHeight
        {
            get
            {
                return maxHeight;
            }
            set
            {
                maxHeight = value;
            }
        }
    }
}
