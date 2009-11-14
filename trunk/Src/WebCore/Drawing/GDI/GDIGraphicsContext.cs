using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
