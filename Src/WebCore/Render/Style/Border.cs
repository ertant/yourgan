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
    public class Border
    {
        public Border()
        {
        }

        private BorderValue left = new BorderValue();

        public BorderValue Left
        {
            get { return left; }
        }

        private BorderValue top = new BorderValue();

        public BorderValue Top
        {
            get { return top; }
        }

        private BorderValue right = new BorderValue();

        public BorderValue Right
        {
            get { return right; }
        }

        private BorderValue bottom = new BorderValue();

        public BorderValue Bottom
        {
            get { return bottom; }
        }

        public bool HasBorder
        {
            get
            {
                return !this.left.IsZero || !this.top.IsZero || !this.right.IsZero || !this.bottom.IsZero;
            }
        }
    }
}
