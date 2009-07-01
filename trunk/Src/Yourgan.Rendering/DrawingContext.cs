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
using System.Drawing;

namespace Yourgan.Rendering
{
    public class DrawingContext
    {
        public DrawingContext(Graphics graphics)
        {
            this.graphics = graphics;
        }

        private Graphics graphics;

        public Graphics Graphics
        {
            get
            {
                return graphics;
            }
        }

        Stack<System.Drawing.Drawing2D.Matrix> transformStack = new Stack<System.Drawing.Drawing2D.Matrix>();

        public void PushTransform()
        {
            transformStack.Push(this.graphics.Transform);
        }

        public void PopTransform()
        {
            this.graphics.Transform = transformStack.Pop();
        }

        public void Translate(float dx, float dy)
        {
            this.graphics.TranslateTransform(dx, dy);
        }
    }
}
