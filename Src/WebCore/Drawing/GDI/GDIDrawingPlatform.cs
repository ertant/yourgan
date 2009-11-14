using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
