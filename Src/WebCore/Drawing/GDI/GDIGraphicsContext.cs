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
            get { return graphics; }
        }
    }
}
