using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Drawing
{
    public interface IGraphicsContext : IDisposable
    {
        void FillRectangle(System.Drawing.Brush brush, System.Drawing.Rectangle rectangle);
    }
}
