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
    public class FlowLayout : ILayout
    {
        public FlowLayout(GraphicContainer owner)
        {
            this.owner = owner;
        }

        private GraphicContainer owner;

        public GraphicContainer Owner
        {
            get
            {
                return owner;
            }
        }

        private bool isLayoutRequired;

        public bool IsLayoutRequired
        {
            get
            {
                return isLayoutRequired;
            }
        }

        public void Invalidate()
        {
            isLayoutRequired = true;
        }

        public void PerformLayout()
        {
            RectangleF rectangle = owner.Bounds;

            foreach (GraphicObject child in owner.Childs.ToArrayThreadSafe())
            {
                SizeF childSize = child.GetPreferredSize(SizeF.Empty);

                child.Bounds = new RectangleF(rectangle.Location, childSize);

                if (rectangle.X + childSize.Width > rectangle.Width)
                {
                    rectangle.X = 0;
                    rectangle.Y += childSize.Height;
                }
                else
                {
                    rectangle.X += childSize.Width;
                }
            }

            isLayoutRequired = false;
        }

        public void PerformLayoutIfRequired()
        {
            if (isLayoutRequired)
            {
                this.PerformLayout();
            }
        }
    }
}
