using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Rendering
{
    public class GraphicObject
    {
        protected virtual void CorePaint(IRenderingContext context)
        {

        }

        public void Paint(IRenderingContext context)
        {
            CorePaint(context);
        }
    }
}
