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
    public class Surround
    {
        private LengthBox offset;

        public LengthBox Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        private LengthBox margin;

        public LengthBox Margin
        {
            get { return margin; }
            set { margin = value; }
        }

        private LengthBox padding;

        public LengthBox Padding
        {
            get { return padding; }
            set { padding = value; }
        }

        private Border border;

        public Border Border
        {
            get { return border; }
            set { border = value; }
        }
    }
}
