using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yourgan.Core.Drawing
{
    public interface IDrawingPlatform : IDisposable
    {
        void Reset(Size size);

        IGraphicsContext Current
        {
            get;
        }
    }
}
