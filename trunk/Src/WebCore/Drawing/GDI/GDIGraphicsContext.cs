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

namespace Yourgan.Core.Drawing.GDI
{
    public class GDIGraphicsContext : IGraphicsContext
    {
        public GDIGraphicsContext(Image image)
        {
            this.image = image;
            this.graphics = System.Drawing.Graphics.FromImage(image);
        }

        public void Dispose()
        {
            this.graphics.Dispose();
        }

        private Image image;

        public Image Image
        {
            get { return image; }
        }

        private Graphics graphics;

        public Graphics Graphics
        {
            get
            {
                if (graphics == null)
                {
                    graphics = System.Drawing.Graphics.FromImage(image);
                }

                return graphics;
            }
        }

        public void FillRectangle(System.Drawing.Brush brush, System.Drawing.Rectangle rectangle)
        {
            this.Graphics.FillRectangle(brush, rectangle);
        }
    }
}
