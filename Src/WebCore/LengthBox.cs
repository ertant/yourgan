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
namespace Yourgan.Core
{
    public class LengthBox
    {
        private Length left;

        public Length Left
        {
            get { return left; }
            set { left = value; }
        }

        private Length top;

        public Length Top
        {
            get { return top; }
            set { top = value; }
        }

        private Length right;

        public Length Right
        {
            get { return right; }
            set { right = value; }
        }

        private Length bottom;

        public Length Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        public bool IsZero()
        {
            return this.left.IsZero() && this.top.IsZero() && this.right.IsZero() && this.bottom.IsZero();
        }
    }
}
