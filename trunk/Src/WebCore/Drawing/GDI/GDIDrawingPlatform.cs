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
using System;
using System.Drawing;

namespace Yourgan.Core.Drawing.GDI
{
    public class GDIDrawingPlatform : IDrawingPlatform, IDisposable
    {
        public GDIDrawingPlatform()
        {
        }

        public void Dispose()
        {
            this.current.Dispose();
        }

        private GDIGraphicsContext current;

        public IGraphicsContext Current
        {
            get
            {
                return current;
            }
        }

        public void Reset(Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GDIGraphicsContext context = new GDIGraphicsContext(bitmap);

            if (this.current != null)
                this.current.Dispose();

            this.current = context;
        }

        public void Render(Graphics g, Rectangle clip)
        {
            if (current != null)
            {
                current.Image.Save("d:\\test.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                g.DrawImage(current.Image, 0, 0);
            }
        }
    }
}
