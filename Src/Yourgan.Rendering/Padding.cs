﻿// /*
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
namespace Yourgan.Rendering
{
    public class Padding
    {
        public Padding()
        {
        }

        public Padding(float all)
        {
            this.top = all;
        }

        private bool all = true;

        public float All
        {
            get
            {
                if (all)
                    return this.top;
                else
                    return -1;
            }
            set
            {
                this.top = value;
                all = false;
            }
        }

        private float left;

        public float Left
        {
            get
            {
                if (all)
                    return this.top;
                else
                    return left;
            }
            set
            {
                left = value;
                all = false;
            }
        }

        private float right;

        public float Right
        {
            get
            {
                if (all)
                    return this.top;
                else
                    return right;
            }
            set
            {
                right = value;
                all = false;
            }
        }

        private float top;

        public float Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

        private float bottom;

        public float Bottom
        {
            get
            {
                if (all)
                    return this.top;
                else
                    return bottom;
            }
            set
            {
                bottom = value;
                all = false;
            }
        }

        public float Vertical
        {
            get
            {
                return this.Top + this.Bottom;
            }
        }

        public float Horizontal
        {
            get
            {
                return this.Left + this.Right;
            }
        }
    }
}
